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
   public class CountryRepo : RepositoryBase<LookUp_Country>, ICountryRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public CountryRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
         public IEnumerable<CountryDTO> GetAll()
         {

             return Get().Where(x=>!x.IsDeleted).Select(x => new CountryDTO { CountryID = (int)x.CountryID, CountryName = x.CountryName });
         }
        public IEnumerable<LookupDTO> GetAllasLookup()
        {

            return Get().Where(x => !x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.CountryID, Value = x.CountryName });
        }

        /*
         public IEnumerable<LookupDTO> GetAllasLookup()
         {

             return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
         }*/
        public CountryDTO GetbyId(long id)
        {
            var cat = GetById(id);
            return new CountryDTO
            {
                CountryName = cat.CountryName,
                CountryID = (int)cat.CountryID
            };
        }
        
        public async Task Post(CountryDTO model)
        {
            var entity = new LookUp_Country()
            {
                CountryName = model.CountryName,
                IsDeleted = false,
                //OrderBy = 0,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(CountryDTO model)
        {
            var entity = GetById(model.CountryID);
            if (entity != null)
            {
                entity.CountryName = model.CountryName;

                Put(entity);
            }
        }


        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
