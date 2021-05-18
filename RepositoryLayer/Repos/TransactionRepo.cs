using AutoMapper;
using CommonLayer.DTOs;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repos
{
   public class TransactionRepo : RepositoryBase<Accounts_Transacation>, ITransactionRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public TransactionRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<Accounts_Transacation> GetAll()
        {
            return Get();
        }

        public async Task Post(TransactionDTO model)
        {

            var entity = new Accounts_Transacation()
            {

            };
            await Post(entity);
        }
        public void Put(TransactionDTO model)
        {
            var entity = GetById(model.Account_Transaction_ID);
            if (entity != null)
            {

                Put(entity);
            }
        }


        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
