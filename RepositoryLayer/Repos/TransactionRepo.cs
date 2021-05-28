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
        public IEnumerable<ParentTransactionDTO> GetAll()
        {
            return Get().Select(x => new ParentTransactionDTO
            {
                ID =(int) x.ID ,
                Date = x.Date,
                Type = x.Type,
                Description = x.Description,
                GUIDID =x.GUIDID
            });
        }

        public async Task Post(ParentTransactionDTO model)
        {
            var entity = new Accounts_Transacation()
            {
                ID=model.ID,
                Type=model.Type,
                Description=model.Description,
                GUIDID=model.GUIDID,
                Date=model.Date,
                CreatedBy=Utils.GetUserId(_serviceProvider),
                CreatedDate= DateTime.Now
            };
            await Post(entity);
        }
        public async Task<long> PostRemotly(ParentTransactionDTO model)
        {
            var entity = new Accounts_Transacation()
            {
                ID = model.ID,
                Type = model.Type,
                Description = model.Description,
                GUIDID = model.GUIDID,
                Date = model.Date,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now
            };
            await Post(entity,true);
            return entity.ID;
        }
        public ParentTransactionDTO GetbyId(int id)
        {
            var tran = GetById(id);
            return new ParentTransactionDTO
            {
                ID = (int)tran.ID,
                Date = tran.Date,
                Type = tran.Type,
                Description = tran.Description,
                GUIDID = tran.GUIDID
            };
        }
        public void Put(ParentTransactionDTO model)
        {
            var entity = GetById(model.ID);
            if (entity != null)
            {
                entity.ID = (int)model.ID;
                entity.Date = model.Date;
                entity.Type = model.Type;
                entity.Description = model.Description;
                entity.GUIDID = model.GUIDID;
                Put(entity);
            }
        }
        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
