using CommonLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Payroll;

namespace RepositoryLayer.Infrastructures
{
    public interface IServiceTypeRepo: IRepositoryBase<RC_Payroll_Service_Type>
    {
        IEnumerable<ServiceTypeDTO> GetAll();
        Task Post(ServiceTypeDTO model);
        ServiceTypeDTO GetbyId(long id);
        void Put(ServiceTypeDTO model);
        void SoftDelete(long id);
    }
}
