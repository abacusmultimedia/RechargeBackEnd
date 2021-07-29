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
    public class EmployeeServiceRepo : RepositoryBase<EmployeeServices>, IEmployeeServiceRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper; 

        public EmployeeServiceRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
         public IEnumerable<EmployeeServicesDTO> GetAll()
         {

             return Get().Where(x => !x.IsDeleted).Select(x => new EmployeeServicesDTO { Id = x.EmployeeServiceId, PaymentOptionId = x.PaymentOption });
         }
       
        /* public FormDTO GetbyId(long id)
         {
             var cat = GetById(id);
             return new FormDTO
             {
                 Title = cat.Title,
                 Order = cat.Order,
                 Id = cat.Id
             };
         }*/
       
        public async Task Post(EmployeeServicesDTO model , long EmpID)
        {
            var entity = new EmployeeServices()
            {
                EmployeeId = EmpID,
                CreatedDate = DateTime.Now,
                ServiveId = model.ServiceId,
                PaymentDate = DateTime.UtcNow,
                ServiceAmount = model.ServiceAmmount,
                PaymentOption = model.PaymentOptionId,
                ServiveProviderId=model.ServiceProviderId,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                EmployeeConsumerNo = model.EmployeeConsumerNo,
            };
            await Post(entity);
        }
 



        public void Put(EmployeeServicesDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.PaymentDate = DateTime.UtcNow;
                entity.ServiceAmount = model.ServiceAmmount;
                entity.PaymentOption = model.PaymentOptionId;
                entity.ServiveProviderId = model.ServiceProviderId;
                entity.EmployeeConsumerNo = model.EmployeeConsumerNo;
                Put(entity);
            }

        }

        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
