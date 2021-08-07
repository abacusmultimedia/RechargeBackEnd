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
   public class JobTitleRepo : RepositoryBase<Lookup_Job_Title>, IJobTitleRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public JobTitleRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<LookupDTO> GetAll()
        {

            return Get().Where(x => !x.IsDeleted).Select(x => new LookupDTO { Key = x.key, Value = x.Title });
        }
        
        public LookupDTO GetbyId(int id)
        {
            var cat = GetById(id);
            return new LookupDTO
            {
                Key = cat.key,
                Value = cat.Title
            };
        }

        public async Task Post(LookupDTO model)
        {
            var entity = new Lookup_Job_Title()
            {
                key = model.Key,
                Title =model.Value,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
               
            };
            await Post(entity);
        }
        public void Put(LookupDTO model)
        {
            var entity = GetById(model.Key);
            if (entity != null)
            {
                entity.Title = model.Value;

                Put(entity);
            }
        }
        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
