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
   public class FormRepo : RepositoryBase<Form>, IFormRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public FormRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, EntityLayer.RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        #region Form
        public IEnumerable<FormDTO> GetAll()
        {

            return Get().Where(x => !x.IsDeleted).Select(x => new FormDTO { Id = x.Id, Title = x.Title });
        }
        /*     public IEnumerable<FormDTO> GetAllasLookup()
             {

                 return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
             }*/
        
        public FormDTO GetbyId(long id)
        {
            var cat = GetById(id);
            return new FormDTO
            {
                Title = cat.Title,
                Order = cat.Order,
                Id = cat.Id
            };
        }
        public async Task Post(FormDTO model)
        {

            var entity = new Form()
            {
                Title = model.Title,
                IsDeleted = false,
                Order = model.Order,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(FormDTO model)
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
        #endregion
        #region Fields

        #endregion

    }
}
