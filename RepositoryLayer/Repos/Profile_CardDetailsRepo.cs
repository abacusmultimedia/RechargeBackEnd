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
    public class Profile_CardDetailsRepo : RepositoryBase<RC_Profile_CardDetails>, IProfile_CardDetailsRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public Profile_CardDetailsRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<RC_Profile_CardDetails> GetAll()
        {
            return Get();
        }

        public async Task Post(CardDTO model)
        {
            var entity = new RC_Profile_CardDetails()
            {
                CardTypeID = model.CardTypeID,
                CardNumber = model.CardNumber,
                ExpirationDate = model.ExpirationDate,
                CVVCode = model.CVVCode,
                BillingAddress = model.BillingAddress,
                Email = model.BillingAddress,
                UserID = Utils.GetUserId(_serviceProvider),
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now
            };
            await Post(entity);
        }
        public void Put(CardDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.CardTypeID = model.CardTypeID;
                entity.CardNumber = model.CardNumber;
                entity.ExpirationDate = model.ExpirationDate;
                entity.CVVCode = model.CVVCode;
                entity.BillingAddress = model.BillingAddress;
                entity.Email = model.BillingAddress;
                entity.UserID = Utils.GetUserId(_serviceProvider);
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.ModifiedDate = DateTime.Now;

                Put(entity);
            }
        }
        public async Task PostInitial(RC_Profile_CardDetails entity)
        {
            await Post(entity, true);
        }
        public IEnumerable<CardDTO> GetByType(long type)
        {
            var userId = Utils.GetUserId(_serviceProvider);
            var result = Get().Where(x => !x.IsDeleted && x.UserID == userId && x.CardTypeID == type).Select(x => new CardDTO { CardHoldername= x.CardHoldername, CardNumber = x.CardNumber });
            return result;
           
        }
        public void PutByType(CardDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.CardTypeID = model.CardTypeID;
                entity.CardNumber = model.CardNumber;
                entity.CardHoldername = model.CardHoldername;
                entity.ExpirationDate = model.ExpirationDate;
                entity.CVVCode = model.CVVCode;
                entity.BillingAddress = model.BillingAddress;
                entity.Email = model.BillingAddress;
                entity.UserID = Utils.GetUserId(_serviceProvider);
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.ModifiedDate = DateTime.Now;
                Put(entity);
            }
        }
            public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
