using CommonLayer.DTOs;
using EntityLayer;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Payroll;

namespace RepositoryLayer.Repos
{
    public class ServiceProviderTypeRepo:RepositoryBase<RC_Payroll_ServiceProvider_Type>, IServiceProviderTypeRepo
    {
        private readonly IServiceProvider _serviceProvider;
        public ServiceProviderTypeRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<ServiceProviderTypeDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new ServiceProviderTypeDTO { Id = x.Id, Name = x.Name });

        }
        public ServiceProviderTypeDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new ServiceProviderTypeDTO
            {
                Id = entity.Id,
               Name=entity.Name,
            };
        }
        public async Task Post(ServiceProviderTypeDTO model)
        {
            var entity = new RC_Payroll_ServiceProvider_Type()
            {
                Name = model.Name
            };
            await Post(entity);
        }
        public void Put(ServiceProviderTypeDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
