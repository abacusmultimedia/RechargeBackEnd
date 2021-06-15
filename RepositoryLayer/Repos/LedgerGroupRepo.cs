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
    public class LedgerGroupRepo : RepositoryBase<Accounts_LedgerGroup>, ILedgerGroupRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public LedgerGroupRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<LookupDTO> GetAll()
        {
            return Get().Select(x => new LookupDTO { Key =(int) x.ID,  Value = x.UnderGroup });
        }

        public async Task Post(LedgerGroupDTO model)
        { 
            var entity = new Accounts_LedgerGroup()
            {
                ID=model.Id,
                UnderGroup=model.UnderGroup
            };
            await Post(entity);
        }

       
        public void Put(LedgerGroupDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.UnderGroup = model.UnderGroup;
                entity.ID = model.Id;
                Put(entity);
            }
        }
        public LedgerGroupDTO GetbyId(long id)
        {
            var cat = GetById(id);
            return new LedgerGroupDTO
            {
                Id = cat.ID,
                UnderGroup = cat.UnderGroup

            };
        }
        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }

    }
}
