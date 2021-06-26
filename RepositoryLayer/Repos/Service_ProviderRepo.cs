using AutoMapper;
using CommonLayer.DTOs;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class Service_ProviderRepo : RepositoryBase<RC_Payroll_ServiceProvider>,IService_ProviderRepo
    {
        private readonly IServiceProvider _serviceProvider;
        public Service_ProviderRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<ServicesProviderDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new ServicesProviderDTO { Id = x.Id, Type = x.Type, Title=x.Title,Discription=x.Discription });
        }
        public IEnumerable<LookupDTO> GetAllAsLookUp()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.Id, Value = x.Title });
        }
        public ServicesProviderDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new ServicesProviderDTO
            {
                Id=entity.Id,
                Type = entity.Type,
                Title = entity.Title,
                Discription = entity.Discription
            };
        }
       
      /*  public List<ServicesProviderDTO> GetCityByState(long id)
        {
            var cat = GetWithCondition(x => x.Id == id).Select(x => new ServicesProviderDTO
            {
                Value = x.CityName,
                Key = (int)x.C
            });
            return cat.ToList();
        }*/
        public async Task Post(ServicesProviderDTO model)
        {
            var entity = new RC_Payroll_ServiceProvider()
            {
                Id=model.Id,
                IsDeleted = false,
                Type = model.Type,
                Title=model.Title,
                Discription=model.Discription,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(ServicesProviderDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Title = model.Title;
                entity.Discription = model.Discription;
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
