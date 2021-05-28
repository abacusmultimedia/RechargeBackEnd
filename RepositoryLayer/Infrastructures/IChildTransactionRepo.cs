using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IChildTransactionRepo : IRepositoryBase<Accounts_childTransaction>
    {
        IEnumerable<TransactionDTO> GetAll();
        Task Post(TransactionDTO model);
        public void Put(TransactionDTO model);
        void SoftDelete(int id);
    }
}
 