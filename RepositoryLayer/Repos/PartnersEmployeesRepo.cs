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
using static EntityLayer.Entities.Payroll;

namespace RepositoryLayer.Repos
{
    public class PartnersEmployeesRepo : RepositoryBase<RC_Partners_Employees>, IPartners_EmployeesRepo
    {
        private readonly IEmployeeServiceRepo _employeeServiceRepo;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public PartnersEmployeesRepo(IServiceProvider serviceProvider,
            IEmployeeServiceRepo employeeServiceRepo, IExtendedUsersRepo extendedUsersRepo,
            RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            _employeeServiceRepo = employeeServiceRepo;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();

        }
        public IEnumerable<PartnersEmployeesDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x =>
            new PartnersEmployeesDTO
            {
                ID = x.ID,
                FullName = x.F_Name,
                //L_Name = x.L_Name,
                ImageUrl = x.ImageUrl,
                JobTitle = x.JobTitle
            });
        }
        public PartnersEmployeesDTO GetbyId(long id)
        {
            var partnersEmp = GetById(id);
            return new PartnersEmployeesDTO
            {
                FullName = partnersEmp.F_Name,
                //L_Name = partnersEmp.L_Name,
                ImageUrl = partnersEmp.ImageUrl,
            };
        }
        public async Task Post(PartnersEmployeesDTO model)
        {
            var entity = new RC_Partners_Employees()
            {
                F_Name = model.FullName,
                //L_Name = model.L_Name,
                ImageUrl = model.ImageUrl,
                JobTitle = model.JobTitle,
                IsDeleted = false,
                EmployerId = Utils.GetUserId(_serviceProvider),
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public async Task PostWithService(EmployeewithServicesDTO employeewithServicesDTO)
        {
            var model = employeewithServicesDTO.Employee;
            var entity = new RC_Partners_Employees()
            {
                IsDeleted = false,
                F_Name = model.FullName,
                //L_Name = model.L_Name,
                ImageUrl = model.ImageUrl,
                JobTitle = model.JobTitle,
                CreatedDate = DateTime.Now,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                EmployerId = Utils.GetUserId(_serviceProvider),
                EmployeeServices = MappServices(employeewithServicesDTO.Services)
            };
            await Post(entity, true); 
        }
        private   List<EmployeeServices>  MappServices(List<EmployeeServicesDTO> model)
        {
            var ListofServices = new List<EmployeeServices>();
            foreach (var item in model)
            {
                var temp = new EmployeeServices()
                { 
                    IsDeleted = false,
                    ServiveId = item.ServiceId,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.UtcNow,
                    PaymentDate = item.ExpirationDate,
                    ServiceAmount = item.ServiceAmmount,
                    PaymentOption = item.PaymentOptionId,
                    ServiveProviderId = item.ServiceProviderId,
                    CreatedBy = Utils.GetUserId(_serviceProvider),
                    EmployeeConsumerNo = item.EmployeeConsumerNo,
                    ModifiedBy = Utils.GetUserId(_serviceProvider),
                };
                 
                ListofServices.Add(temp);
            }
            return ListofServices;
        }
        public void Put(PartnersEmployeesDTO model)
        {
            var entity = GetById(model.ID);
            if (entity != null)
            {
                entity.F_Name = model.FullName;
                //entity.L_Name = model.L_Name;
                entity.ImageUrl = model.ImageUrl;
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }

        public bool IsExist(long id)
        {
            var userExist = Get().Where(s => s.ID == id).Count();
            if (userExist == 0)
                return false;
            return true;
        }
    }
}
