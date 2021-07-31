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
   public class AdvertisementRepo : RepositoryBase<Advertisement>, IAdvertisementRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public AdvertisementRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, EntityLayer.RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<AdvertisementDTO> GetAll()
        {

            return Get().Where(x => !x.IsDeleted).Select(x => new AdvertisementDTO { Id = x.Id, ImageUrl = x.ImageUrl, Title = x.Title });
        }
       
        public AdvertisementDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new AdvertisementDTO
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Title = entity.Title,
            };
         }   
        public async Task Post(AdvertisementDTO model)
        {

            var entity = new Advertisement()
            {
                ImageUrl=model.ImageUrl,
                Title=model.Title,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(AdvertisementDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.ImageUrl = model.ImageUrl;
                entity.Title = model.Title;
                Put(entity);
            }

        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
