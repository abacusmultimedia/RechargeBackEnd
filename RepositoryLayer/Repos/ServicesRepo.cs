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
using static EntityLayer.Entities.Payroll;

namespace RepositoryLayer.Repos
{
    public class ServicesRepo: RepositoryBase<RC_Payroll_Service>, IServicesRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public ServicesRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<ServicesDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new ServicesDTO { Id = x.Id, Title = x.Title, Type=x.Type});
        }
        public IEnumerable<LookupDTO> GetAllAsLookUp()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.Id, Value = x.Title });
        }

        public ServicesDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new ServicesDTO
            {
                Title = entity.Title,
                Id = entity.Id,
                Type = entity.Type
            };
        }
        /*public List<ServicesDTO> GetCityByState(long id)
        {
            var cat = GetWithCondition(x => x.Id == id).Select(x => new ServicesDTO
            {
                Id = x.Id,
                Title = x.Title,
            });
            return cat.ToList();
        }*/
        public async Task Post(ServicesDTO model)
        {
            var entity = new RC_Payroll_Service()
            {
                Id = model.Id,
                IsDeleted = false,
                Title = model.Title,
                Type =model.Type,
                //OrderBy = 1,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(ServicesDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Title = model.Title;
                entity.Type = model.Type;
                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
