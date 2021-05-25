using CommonLayer.DTOs;
using AutoMapper;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace RepositoryLayer.Repos
{
    public class  Profile_BankingDetailsRepo : RepositoryBase<RC_Profile_BankingDetails>, IProfile_BankingDetailsRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public Profile_BankingDetailsRepo(IServiceProvider serviceProvider,RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<RC_Profile_BankingDetails> GetAll()
        {
            return  Get(); 
        }
     
        public async Task Post(BankDetails model)
        {

            var entity = new RC_Profile_BankingDetails()
            {
                BnakName = model.bank,
                BranchCode = model.branchCode,
                AccountNumber = model.accountNo,
                AccountHolderName = model.accountHolderName,
                UserID = Utils.GetUserId(_serviceProvider),
                CreatedBy= Utils.GetUserId(_serviceProvider),
                CreatedDate =DateTime.Now

            };
            await Post(entity);    
        }
        public async Task PostInitial(RC_Profile_BankingDetails entity)
        {

            await Post(entity,true);
        }

        public void Put(BankDetails model)
        {
            var entity = GetById(model.Id); 
            if (entity != null)
            {
                entity.BnakName = model.bank;
                entity.BranchCode = model.branchCode;
                entity.AccountNumber = model.accountNo;
                entity.AccountHolderName = model.accountHolderName;
                entity.UserID = Utils.GetUserId(_serviceProvider);
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.ModifiedDate = DateTime.Now;
                entity.IsDeleted = false;
 
                Put(entity);
            }
        }
 

        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }


    }
}
