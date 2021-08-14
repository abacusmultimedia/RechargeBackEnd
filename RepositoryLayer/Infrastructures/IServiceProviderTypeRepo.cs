using CommonLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Payroll;

namespace RepositoryLayer.Infrastructures
{
    public interface IServiceProviderTypeRepo:IRepositoryBase<RC_Payroll_ServiceProvider_Type>
    {
        IEnumerable<ServiceProviderTypeDTO> GetAll();
        Task Post(ServiceProviderTypeDTO model);
        ServiceProviderTypeDTO GetbyId(long id);
        void Put(ServiceProviderTypeDTO model);
        void SoftDelete(long id);
    }
}
