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
        IEnumerable<Accounts_Ledger> GetAll();
        Task Post(LedgerDTO model);
        void Put(LedgerDTO model);
        void SoftDelete(int id);
    }
}
