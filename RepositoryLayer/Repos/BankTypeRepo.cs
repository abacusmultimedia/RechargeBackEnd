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
    public class BankTypeRepo : RepositoryBase<LookUp_Bank>, IBankTypeRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public BankTypeRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<LookupDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.ID, Value = x.BankName });
        }

        public BankTypeDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new BankTypeDTO
            {
                ID = entity.ID,
                BankName = entity.BankName,
            };
        }

        public async Task Post(BankTypeDTO model)
        {
            var entity = new LookUp_Bank()
            {
                ID = model.ID,
                BankName = model.BankName,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,

            };
            await Post(entity);
        }
        public void Put(BankTypeDTO model)
        {
            var entity = GetById(model.ID);
            if (entity != null)
            {
                entity.BankName = model.BankName;

                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}


