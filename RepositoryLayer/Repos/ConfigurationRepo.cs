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
    public class ConfigurationRepo:RepositoryBase<Configuration>, IConfigurationRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public ConfigurationRepo(IServiceProvider serviceProvider,RechargeDbContext context) :base(context)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<ConfigurationDTO> GetAll()
        {

            return Get().Where(x => !x.IsDeleted).Select(x => new ConfigurationDTO { Key = x.Key, Value = x.Value });
        }
        public ConfigurationDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new ConfigurationDTO
            {
                Key = entity.Key,
                Value = entity.Value
            };
        }
        public async Task Post(ConfigurationDTO model)
        {
            var entity = new Configuration()
            {
                Value = model.Value,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(ConfigurationDTO model)
        {
            var entity = GetById(model.Key);
            if (entity != null)
            {
                entity.Value = model.Value;

                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
