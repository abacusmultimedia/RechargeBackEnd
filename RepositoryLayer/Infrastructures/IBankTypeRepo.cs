using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IBankTypeRepo : IRepositoryBase<LookUp_Bank>
    {
        IEnumerable<LookupDTO> GetAll();
        BankTypeDTO GetbyId(long id);
        Task Post(BankTypeDTO model);
        void Put(BankTypeDTO model);
        void SoftDelete(long id);
    }
}
