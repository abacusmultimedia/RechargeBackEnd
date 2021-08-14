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
    public class ServiceTypeRepo:RepositoryBase<RC_Payroll_Service_Type>, IServiceTypeRepo
    {
        private readonly IServiceProvider _serviceProvider;
        public ServiceTypeRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<ServiceTypeDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new ServiceTypeDTO { Id = x.Id, Name = x.Name });

        }
        public ServiceTypeDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new ServiceTypeDTO
            {
                Id = entity.Id,
                Name=entity.Name,
            };
        }
        public async Task Post(ServiceTypeDTO model)
        {
            var entity = new RC_Payroll_Service_Type()
            {
                Name = model.Name
            };
            await Post(entity);
        }
        public void Put(ServiceTypeDTO model)
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
