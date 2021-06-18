using AutoMapper;
using CommonLayer.DTOs;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repos
{
    public class PartnersEmployeesRepo : RepositoryBase<RC_Partners_Employees>, IPartners_EmployeesRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public PartnersEmployeesRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<PartnersEmployeesDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x =>
            new PartnersEmployeesDTO {
                ID=x.ID,
                F_Name = x.F_Name,
                L_Name = x.L_Name,
                ImageUrl=x.ImageUrl });
        }
        public PartnersEmployeesDTO GetbyId(long id)
        {
            var partnersEmp = GetById(id);
            return new PartnersEmployeesDTO
            {
                F_Name = partnersEmp.F_Name,
                L_Name=partnersEmp.L_Name,
                ImageUrl=partnersEmp.ImageUrl,
            };
        }
        public async Task Post(PartnersEmployeesDTO model)
        {
            var entity = new RC_Partners_Employees()
            {
                F_Name = model.F_Name,
                L_Name=model.L_Name,
                ImageUrl=model.ImageUrl,
                JobTitle = model.JobTitle,
                IsDeleted = false,
                //OrderBy = 0,
                EmployerId = Utils.GetUserId(_serviceProvider),
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(PartnersEmployeesDTO model)
        {
            var entity = GetById(model.ID);
            if (entity != null)
            {
                entity.F_Name = model.F_Name;
                entity.L_Name = model.L_Name;
                entity.ImageUrl = model.ImageUrl;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.ModifiedDate = DateTime.Now;
                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
