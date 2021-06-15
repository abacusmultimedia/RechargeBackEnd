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
   public class CityRepo : RepositoryBase<LookUp_City>, ICityRepo
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
         public IEnumerable<LookupDTO> GetAll()
         {

             return Get().Where(x=>!x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.CityID, Value = x.CityName });
         }/*
         public IEnumerable<LookupDTO> GetAllasLookup()
         {

             return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
         }*/
        public CityDTO GetbyId(long id)
        {
            var cat = GetById(id);
            return new CityDTO
            {
                CityName = cat.CityName,
                CityID = (int)cat.CityID
            };
        }
        public List<CityDTO> GetCityByState(long id)
        {
            var cat = GetWithCondition(x=>x.StateID==id).Select(x => new CityDTO 
            {
                CityName = x.CityName,
                CityID = (long)x.CityID,
                StateID=(long)x.StateID
            });
            return cat.ToList();
        }
        public async Task Post(CityDTO model)
        {
            var entity = new LookUp_City()
            {
                CityName = model.CityName,
                IsDeleted = false,
                StateID=model.StateID,
                //OrderBy = 1,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
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
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
