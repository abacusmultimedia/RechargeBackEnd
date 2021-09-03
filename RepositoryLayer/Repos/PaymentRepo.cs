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
using static EntityLayer.Entities.Payment;

namespace RepositoryLayer.Repos
{
    public class PaymentRepo: RepositoryBase<RC_Payment>, IPaymentRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public PaymentRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<PaymentDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new PaymentDTO { Id = x.Id, FrequencyId = x.FrequencyId,TransferEntireBalance=x.TransferEntireBalance,TransferAmount=x.TransferAmount,PayoutOptions=x.PayoutOptions,NextPaymentDate=x.NextPaymentDate });
        }
         
        public PaymentDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new PaymentDTO
            {
                Id = entity.Id,
                FrequencyId = entity.FrequencyId, 
                PayoutOptions = entity.PayoutOptions,
                TransferAmount = entity.TransferAmount,
                NextPaymentDate = entity.NextPaymentDate, 
                TransferEntireBalance = entity.TransferEntireBalance,
            };
        }
        public async Task Post(PaymentDTO model)
        {
            var entity = new RC_Payment()
            {
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                FrequencyId = model.FrequencyId,
                PayoutOptions = model.PayoutOptions,
                TransferAmount = model.TransferAmount,
                NextPaymentDate = model.NextPaymentDate,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                TransferEntireBalance = model.TransferEntireBalance,
            };
            await Post(entity);
        }
        public void Put(PaymentDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.FrequencyId = model.FrequencyId;
                entity.PayoutOptions = model.PayoutOptions;
                entity.TransferAmount = model.TransferAmount;
                entity.NextPaymentDate = model.NextPaymentDate;
                entity.TransferEntireBalance = model.TransferEntireBalance;
                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
