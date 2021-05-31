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
   public class CityRepo : RepositoryBase<City>, ICityRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public CityRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        /* public IEnumerable<StateDTO> GetAll()
         {

             return Get().Select(x => new StateDTO { Key = (int)x.ID, Value = x.Name });
         }
         public IEnumerable<LookupDTO> GetAllasLookup()
         {

             return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
         }*/
        public CityDTO GetbyId(int id)
        {
            var cat = GetById(id);
            return new CityDTO
            {
                CityName = cat.CityName,
                CityID = (int)cat.CityID
            };
        }
        public async Task Post(CityDTO model)
        {
            var entity = new CityDTO()
            {
                CityName = model.CityName,
                //IsDeleted = false,
                //OrderBy = 0,
                //CreatedBy = Utils.GetUserId(_serviceProvider),
                //CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(CityDTO model)
        {
            var entity = GetById(model.CityID);
            if (entity != null)
            {
                entity.CityName = model.CityName;

                Put(entity);
            }
        }
        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
