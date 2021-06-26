using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IPartners_EmployeesRepo : IRepositoryBase<RC_Partners_Employees>
    {
        IEnumerable<PartnersEmployeesDTO> GetAll();
        PartnersEmployeesDTO GetbyId(long id);
        Task Post(PartnersEmployeesDTO model);
        void Put(PartnersEmployeesDTO model);
        void SoftDelete(long id);
        bool IsExist(long id);

    }
}
