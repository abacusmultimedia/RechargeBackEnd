using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Payroll;

namespace RepositoryLayer.Infrastructures
{
    public interface IServicesRepo : IRepositoryBase<RC_Payroll_Service>
    {
        IEnumerable<ServicesDTO> GetAll();
        IEnumerable<LookupDTO> GetAllAsLookUp();
        ServicesDTO GetbyId(long id);
        Task Post(ServicesDTO model);
        void Put(ServicesDTO model);
        void SoftDelete(long id);
    }
}
