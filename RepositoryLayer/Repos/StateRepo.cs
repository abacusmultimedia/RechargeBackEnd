using AutoMapper;
using CommonLayer.DTOs;
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
    public class StateRepo :RepositoryBase<State>, IStateRepo
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
       /* public IEnumerable<StateDTO> GetAll()
        {

            return Get().Select(x => new StateDTO { Key = (int)x.ID, Value = x.Name });
        }
        public IEnumerable<LookupDTO> GetAllasLookup()
        {

            return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
        }*/
        public StateDTO GetbyId(int id)
        {
            var cat = GetById(id);
            return new StateDTO
            {
                StateName = cat.StateName,
                StateID = (int)cat.StateID
            };
        }
        public async Task Post(StateDTO model)
        {
            var entity = new StateDTO()
            {
                StateName = model.StateName,
                //IsDeleted = false,
                //OrderBy = 0,
                //CreatedBy = Utils.GetUserId(_serviceProvider),
                //CreatedDate = DateTime.Now,
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


        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
