using CommonLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Payroll;

namespace RepositoryLayer.Infrastructures
{
   public interface IEmployeeServiceRepo :IRepositoryBase<EmployeeServices>
    {
        IEnumerable<EmployeeServicesDTO> GetAll();
        Task Post(EmployeeServicesDTO model, long EmpID);
        void Put(EmployeeServicesDTO model);
        void SoftDelete(long id);
    }
}
