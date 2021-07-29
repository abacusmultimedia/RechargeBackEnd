using AutoMapper;
using CommonLayer.DTOs;
using CommonLayer.Helpers;
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
    public class FieldsRepo : RepositoryBase<Fields>, IFieldsRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public FieldsRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, EntityLayer.RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<FieldsDTO> GetAll()
        {

            return Get().Where(x => !x.IsDeleted).Select(x => new FieldsDTO { Id = x.Id, FieldsName = x.FieldsName, PlaceHolder = x.PlaceHolder });
        }
        /*     public IEnumerable<FormDTO> GetAllasLookup()
             {

                 return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
             }*/

        public FieldsDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new FieldsDTO
            {
                Id = entity.Id,
                Order = entity.Order,
                TypeID = entity.TypeID,
                FormID = entity.FormID,
                ColSpan = entity.ColSpan,
                isDisabled = entity.isDisabled,
                FieldsName = entity.FieldsName,
                isRequired = entity.isRequired,
                PlaceHolder = entity.PlaceHolder,
                Options = entity.Options.Select(x => new OptionsDTO {
                    Title = x.Title,
                    FieldID = x.FieldID,
                    isDisabled = x.isDisabled,
                    Order = x.Order
                }).OrderBy(e => e.Order).ToList(),
            };
        }

        public async Task Post(FieldsDTO model)
        {

            var entity = new Fields()
            {
                FieldsName = model.FieldsName,
                PlaceHolder = model.PlaceHolder,
                Order = model.Order,
                isDisabled = model.isDisabled,
                ColSpan = model.ColSpan,
                isRequired = model.isRequired,
                TypeID = model.TypeID,
                FormID = model.FormID,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(FieldsDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.FieldsName = model.FieldsName;
                entity.PlaceHolder = model.PlaceHolder;
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
