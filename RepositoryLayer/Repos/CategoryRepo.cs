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
    public class CategoryRepo : RepositoryBase<Category>, ICategoryRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public CategoryRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public  IEnumerable<LookupDTO> GetAll()
        {

            return Get().Select(x => new LookupDTO { Key =   (int) x.ID ,  Value = x.Name }) ;
        }
        public IEnumerable<LookupDTO> GetAllasLookup()
        {

            return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
        }
        public CategoryDTO GetbyId(int id)
        {
            var cat = GetById(id);
            return new CategoryDTO { 
               CategoryName = cat.Name,
               Id = (int) cat.ID
            };
        }
        public async Task Post(CategoryDTO model)
        {

            var entity = new Category()
            {
                Name = model.CategoryName,
                IsDeleted = false,
                OrderBy=   0,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(CategoryDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Name = model.CategoryName;
                

                Put(entity);
            }
        }


        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }

    }
}
