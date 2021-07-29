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
    public class Profile_BankingDetailsRepo : RepositoryBase<RC_Profile_BankingDetails>, IProfile_BankingDetailsRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public Profile_BankingDetailsRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<RC_Profile_BankingDetails> GetAll()
        {
            return Get();
        }

        public async Task Post(BankDetailsDTO model)
        {

            var entity = new RC_Profile_BankingDetails()
            {
                BnakName = model.Bank,
                CreatedDate = DateTime.Now,
                BranchCode = model.BranchCode,
                AccountNumber = model.AccountNo,
                UserID = Utils.GetUserId(_serviceProvider),
                AccountHolderName = model.AccountHolderName,
                CreatedBy = Utils.GetUserId(_serviceProvider),

            };
            await Post(entity);
        }
        public async Task PostInitial(RC_Profile_BankingDetails entity)
        {

            await Post(entity, true);
        }
        public void PutInitial(signUpstage4DTO model)
        {
            var entity = GetWithCondition(e => e.UserID == Utils.GetUserId(_serviceProvider)).FirstOrDefault();
            if (entity != null)
            {
                entity.IsDeleted = false;
                entity.BnakName = model.Bank;
                entity.ModifiedDate = DateTime.Now;
                entity.BranchCode = model.BranchCode;
                entity.AccountNumber = model.AccountNumber;
                entity.AccountHolderName = model.AccountHolderName;
                entity.UserID = Utils.GetUserId(_serviceProvider);
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                Put(entity);
            }
        }

        public void Put(BankDetailsDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.IsDeleted = false;
                entity.BnakName = model.Bank;
                entity.ModifiedDate = DateTime.Now;
                entity.BranchCode = model.BranchCode;
                entity.AccountNumber = model.AccountNo;
                entity.AccountHolderName = model.AccountHolderName;
                entity.UserID = Utils.GetUserId(_serviceProvider);
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);

                Put(entity);
            }
        }
        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }


    }
}
