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
   public class ChildTransactionRepo : RepositoryBase<Accounts_childTransaction>, IChildTransactionRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public ChildTransactionRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<Accounts_childTransaction> GetAll()
        {
            return Get();
        }

        public async Task Post(TransactionDTO model)
        {

            var entity = new Accounts_childTransaction()
            {

            };
            await Post(entity);
        }
        public void Put(TransactionDTO model)
        {
            var entity = GetById(model.Account_ChildTransaction_ID);
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
