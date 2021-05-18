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
        IEnumerable<Accounts_LedgerGroup> GetAll();
        Task Post(LedgerDTO model);
        void Put(LedgerDTO model);
        void SoftDelete(int id);
    }
}
