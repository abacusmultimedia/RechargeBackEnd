using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ILedgerRepo : IRepositoryBase<Accounts_Ledger>
    {
        IEnumerable<LookupDTO> GetAll();
        Task Post(LedgerDTO model);
        void Put(LedgerDTO model);
        LedgerDTO GetbyId(long id);
        void SoftDelete(long id);
    }
}
