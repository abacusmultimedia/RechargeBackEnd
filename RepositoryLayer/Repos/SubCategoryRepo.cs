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
    public class SubCategoryRepo : RepositoryBase<SubCategory>, ISubCategoryRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public SubCategoryRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        public IEnumerable<LookupDTO> GetAll()
        {
            return Get().Select(x=> new LookupDTO { Key = (int)  x.ID, Value = x.Name });
        }

        public async Task Post(SubCategoryDTO model)
        {

            var entity = new SubCategory()
            {
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
                Name = model.SubCategoryName,
                IsDeleted = false,
                ParentID=model.ParentId,
                OrderBy = model.SubOrderBy,
            };
            await Post(entity);
        }
        public void Put(SubCategoryDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Name = model.SubCategoryName;
                Put(entity);
            }
        }
        public SubCategoryDTO GetbyId(int id)
        {
            var cat = GetById((long)id);
            return new SubCategoryDTO
            {
                SubCategoryName = cat.Name,
                Id = (int)cat.ID,
                ParentId = (int)cat.ParentID

            };
        }

        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }

    }
}

