using AutoMapper;
using CommonLayer.DTOs;
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
        public IEnumerable<LookupDTO> GetAll()
        {
            return Get().Select(x => new LookupDTO { Key = (int) x.ID, Value = x.Title });
        }

        public async Task Post(LedgerDTO model)
        {
            var entity = new Accounts_Ledger()
            {
                //ID = model.Id,
                UserID = model.UserID,
                StartDate = DateTime.UtcNow,
                openingBalance = model.openingBalance,
                Title = model.Title,
                ParentLedgerGroupID = model.ParentLedgerGroupID
            };
            await Post(entity);
        }
        public LedgerDTO GetbyId(long id)
        {
            var cat = GetById(id);
            return new LedgerDTO
            {
                Title = cat.Title,
                UserID = cat.UserID,
                openingBalance = cat.openingBalance
            };
        }
        public void Put(LedgerDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.UserID = model.UserID;
                entity.Title = model.Title;
                entity.openingBalance = model.openingBalance;
                entity.ParentLedgerGroupID = model.ParentLedgerGroupID;
                entity.StartDate = DateTime.UtcNow;
                Put(entity);
            }
        }

        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }

    }
}
