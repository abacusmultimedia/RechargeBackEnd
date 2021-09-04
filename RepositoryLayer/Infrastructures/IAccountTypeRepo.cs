using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IAccountTypeRepo : IRepositoryBase<Lookup_AccountType>
    {
        IEnumerable<LookupDTO> GetAll();
        AccountTypeDTO GetbyId(long id);
        Task Post(AccountTypeDTO model);
        void Put(AccountTypeDTO model);
        void SoftDelete(long id);
    }
}
