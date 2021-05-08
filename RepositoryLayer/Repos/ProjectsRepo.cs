using CommonLayer.DTOs;
using AutoMapper;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace RepositoryLayer.Repos
{
    public class ProjectsRepo : RepositoryBase<SBI_Project>, IProjectsRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public ProjectsRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo , RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            return _mapper.Map<List<ProjectDTO>>(Get()); 
        }
        public ProjectDTO GetProjectById(int id)
        {   
                var rawproject = Get().Where(x => x.SBI_Project_Key == id).FirstOrDefault();
                var project = _mapper.Map<ProjectDTO>(rawproject);
            
            return project;

        }
        public IEnumerable<ProjectDTO> GetbyOwner(string UserId)
        {
            return _mapper.Map<List<ProjectDTO>>(Get().Where(x=>x.SBI_Project_owner == UserId));
        }



        public async Task Post(ProjectDTO model)
        {
            SendEmails(model.invitationEmails);
            var entity = new SBI_Project()
            {
              //  SBI_Project_VisibilityType = model.VisibilityType,
                SBI_Project_CanInviteMoreId = model.whoCanInvite,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                SBI_Project_ProjectName = model.ProjectName,
                SBI_Project_Description = model.Description,
                SBI_Project_StarDate = model.StartDate,
                SBI_Project_EndDate = model.EndDate,
                SBI_Project_owner = model.Owner,
                SBI_Group_Key = model.GroupId,
              ///  SBI_Project_Type = model.Type,
                CreatedDate = DateTime.Now,
                ModifiedDate=DateTime.Now,
                ModifiedBy="",
                IsDeleted =false 
            };
            await Post(entity);
            var id = entity.SBI_Project_Key;
            
        }

        private void postFeatures(int id, List<int>fList)
        {

        }
        public void SendEmails(List<string> emailAddresses)
        {
            foreach (var item in emailAddresses)
            {
                _extendedUsersRepo.InvitationToJoinProject(item);
            }
        }
        public void Put(ProjectDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
              ///  entity.SBI_Project_VisibilityType = model.VisibilityType;
                entity.SBI_Project_CanInviteMoreId = model.whoCanInvite;
                entity.CreatedBy = Utils.GetUserId(_serviceProvider);
                entity.SBI_Project_ProjectName = model.ProjectName;
                entity.SBI_Project_Description = model.Description;
                entity.SBI_Project_StarDate = model.StartDate;
                entity.SBI_Project_EndDate = model.EndDate;
                entity.SBI_Project_owner = model.Owner;
                entity.SBI_Group_Key = model.GroupId;
              ///  entity.SBI_Project_Type = model.Type;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.ModifiedDate = DateTime.UtcNow;
                /////////////////////////////////// need file management
                Put(entity);
            }
        }

        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }


    }
}
