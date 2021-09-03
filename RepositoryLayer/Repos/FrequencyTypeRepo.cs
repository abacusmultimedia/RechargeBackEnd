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
using static EntityLayer.Entities.Payment;

namespace RepositoryLayer.Repos
{
    public class FrequencyTypeRepo : RepositoryBase<LookUp_Frequency>, IFrequencyTypeRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public FrequencyTypeRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<LookupDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.Id, Value = x.Name });
        }

        public FrequencyTypeDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new FrequencyTypeDTO
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public async Task Post(FrequencyTypeDTO model)
        {
            var entity = new LookUp_Frequency()
            {
                Id = model.Id,
                Name = model.Name,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,

            };
            await Post(entity);
        }
        public void Put(FrequencyTypeDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;

                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}

