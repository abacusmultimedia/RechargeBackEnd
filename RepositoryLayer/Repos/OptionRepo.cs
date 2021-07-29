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
    public class OptionRepo : RepositoryBase<Options> , IOptionRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public OptionRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<OptionsDTO> GetAll()
        {

            return Get().Where(x => !x.IsDeleted).Select(x => new OptionsDTO { Id = x.Id, Title = x.Title,Order = x.Order });
        }
        //public IEnumerable<LookupDTO> GetAllasLookup()
        //{

        //    return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
        //}
        public OptionsDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new OptionsDTO
            {
                Title = entity.Title,
                Order=entity.Order,
                Id = entity.Id
            };
        }
        public List<OptionsDTO> GetOptionsByFieldId(long Id)
        {
            var entity = GetWithCondition(x => x.FieldID == Id).Select(x => new OptionsDTO
            {
                FieldID = x.FieldID,
                Order = x.Order,
                isDisabled = x.isDisabled

            });
            return entity.ToList();
        }
        public async Task Post(OptionsDTO model)
        {

            var entity = new Options()
            {
                Title = model.Title,
                Order = model.Order,
             
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(OptionsDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Title = model.Title;
                entity.Order = model.Order;
                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
