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
   public class LedgerRepo : RepositoryBase<Accounts_Ledger>, ILedgerRepo 
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public LedgerRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<Accounts_Ledger> GetAll()
        {
            return Get();
        }

        public async Task Post(LedgerDTO model)
        {

            var entity = new Accounts_Ledger()
            {
               
            };
            await Post(entity);
        }
        public void Put(LedgerDTO model)
        {
            var entity = GetById(model.Id);
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
