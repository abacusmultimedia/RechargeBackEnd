using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Payroll;

namespace RepositoryLayer.Infrastructures
{
    public interface IService_ProviderRepo : IRepositoryBase<RC_Payroll_ServiceProvider>
    {
        IEnumerable<ServicesProviderDTO> GetAll();
        IEnumerable<LookupDTO> GetAllAsLookUp();
         ServicesProviderDTO GetbyId(long id);
         Task Post(ServicesProviderDTO model);
        void Put(ServicesProviderDTO model);
        void SoftDelete(long id);
    }
}
