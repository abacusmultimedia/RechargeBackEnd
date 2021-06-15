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
    public class StateRepo :RepositoryBase<LookUp_State>, IStateRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public StateRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
       public IEnumerable<LookupDTO> GetAll()
        {

            return Get().Where(x=> !x.IsDeleted).Select(x => 
            new LookupDTO { Key = (int)x.StateID,  Value = x.StateName });
        }/*
        public IEnumerable<LookupDTO> GetAllasLookup()
        {

            return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
        }*/
        public StateDTO GetbyId(long id)
        {
            var cat = GetById(id);
            return new StateDTO
            {
                StateName = cat.StateName,
                StateID = (int)cat.StateID
                
            };
        }
        public List<LookupDTO> GetByCountryID(long id)
        {
            var cat = GetWithCondition(x=>x.CountryID==id).Select(x=> new LookupDTO
            {
                Value = x.StateName,
                Key = (int)x.StateID 
                
            });
            return cat.ToList();
        }
        public async Task Post(StateDTO model)
        {
            var entity = new LookUp_State()
            {
                StateName = model.StateName,
                IsDeleted = false,
                CountryID=model.CountryID,
                //OrderBy = 0,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(StateDTO model)
        {
            var entity = GetById(model.StateID);
            if (entity != null)
            {
                entity.StateName = model.StateName;

                Put(entity);
            }
        }


        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
