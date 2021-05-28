using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ITransactionRepo : IRepositoryBase<Accounts_Transacation>
    {
        IEnumerable<ParentTransactionDTO> GetAll();
        Task Post(ParentTransactionDTO model);
        public void Put(ParentTransactionDTO model);
        void SoftDelete(int id);
        Task<long> PostRemotly(ParentTransactionDTO model);
    }
}
