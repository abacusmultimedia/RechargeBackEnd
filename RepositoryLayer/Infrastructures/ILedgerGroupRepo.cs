using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface ILedgerGroupRepo : IRepositoryBase<Accounts_LedgerGroup>
    {
        IEnumerable<LookupDTO> GetAll();
        Task Post(LedgerGroupDTO model);
        void Put(LedgerGroupDTO model);
        LedgerGroupDTO GetbyId(long id);
        void SoftDelete(long id);
    }
}
