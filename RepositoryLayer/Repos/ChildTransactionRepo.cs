using AutoMapper;
using CommonLayer.DTOs;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repos
{
   public class ChildTransactionRepo : RepositoryBase<Accounts_childTransaction>, IChildTransactionRepo
    {
        private readonly IServiceProvider _serviceProvider; 
        private readonly ITransactionRepo _transactionRepo;
        public ChildTransactionRepo(IServiceProvider serviceProvider, ITransactionRepo transactionRepo, RechargeDbContext context) : base(context)
        {
            _transactionRepo = transactionRepo;
            _serviceProvider = serviceProvider; 
        }
        public IEnumerable<TransactionDTO> GetAll()
        {
            var list = Get().Select(x=> new {x.LedgerCr.Title, e = x.LedgerDr.Title}).ToList();
            return Get().Select(x => new TransactionDTO {
                Account_ChildTransaction_ID=x.ID,
                Type = x.Type,
                Rate = x.Rate,
                Qty = x.Qty,
                Description = x.Description,
                BillID = x.BillID,
                ProviderRefNo = x.ProviderRefNo,
                ParentTransacatoinID = x.ParentTransacatoinID,
                DrLedger = x.DrLedgerID,
                CrLedger = x.CrLedgerID,
               
            });
        }

        public async Task Post(TransactionDTO model)
        {

            var entity = new Accounts_childTransaction()
            {
                ID=model.Account_ChildTransaction_ID,
                Type=model.Type,
                Rate=model.Rate,
                Qty=model.Qty,
                Description=model.Description,
                BillID=model.BillID,
                ProviderRefNo=model.ProviderRefNo,
                ParentTransacatoinID=model.ParentTransacatoinID,
                DrLedgerID=model.DrLedger,
                CrLedgerID=model.CrLedger,
                CreatedBy= Utils.GetUserId(_serviceProvider),
               CreatedDate=DateTime.Now
            };
            await Post(entity);
        }
        public void Put(TransactionDTO model)
        {
            var entity = GetById(model.Account_ChildTransaction_ID);
            if (entity != null)
            {
                entity.ID = model.Account_ChildTransaction_ID;
                entity.Type = model.Type;
                entity.Rate = model.Rate;
                entity.Qty = model.Qty;
                entity.Description = model.Description;
                entity.BillID = model.BillID;
                entity.ProviderRefNo = model.ProviderRefNo;
                entity.ParentTransacatoinID = model.ParentTransacatoinID;
                entity.DrLedgerID = model.DrLedger;
                entity.CrLedgerID = model.CrLedger;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
               entity.ModifiedDate = DateTime.Now;
                Put(entity);
            }
        }
        public async Task postTransactionWithchild(TransactionWithChildren model)
        {
            long parentid = 0;
            ParentTransactionDTO parentEntity = new ParentTransactionDTO()
            {
                Date = model.Transaction.Date,
                Description = model.Transaction.Description,
                Type ="Payment"
            };
            parentid =  await _transactionRepo.PostRemotly(parentEntity);
            foreach (var item in model.childTransactions)
            {
                Accounts_childTransaction accounts = new Accounts_childTransaction()
                {
                    ParentTransacatoinID = parentid,
                    Description = item.Child_Description,
                    BillID = item.BillID,
                    DrLedgerID = item.DrLedger,
                    CrLedgerID = item.CrLedger,
                    IsDeleted = false,
                    Qty = item.Qty,
                    Rate = item.Rate,
                    CreatedBy = Utils.GetUserId(_serviceProvider),
                    CreatedDate = DateTime.Now,
                    ProviderRefNo = item.ProviderRefNo,
                    Type = "Payment"
                };
                 await Post(accounts);                
            }
        }

        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
