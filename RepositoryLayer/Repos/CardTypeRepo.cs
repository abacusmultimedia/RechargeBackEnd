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
    public class CardTypeRepo : RepositoryBase<LookUp_CardType>, ICardTypeRepo
    {
        private readonly IServiceProvider _serviceProvider;
        public CardTypeRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
        }
        public IEnumerable<LookupDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.ID, Value = x.CardName });
        }

        public CardTypeDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new CardTypeDTO
            {
                ID = entity.ID,
                CardName = entity.CardName,
            };
        }

        public async Task Post(CardTypeDTO model)
        {
            var entity = new LookUp_CardType()
            {
                ID = model.ID,
                CardName = model.CardName,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(CardTypeDTO model)
        {
            var entity = GetById(model.ID);
            if (entity != null)
            {
                entity.CardName = model.CardName;

                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}