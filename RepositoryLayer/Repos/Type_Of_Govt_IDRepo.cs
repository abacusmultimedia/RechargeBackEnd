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
   public class Type_Of_Govt_IDRepo : RepositoryBase<LookUp_Type_Of_Govt_ID>, IType_Govt_IDRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public Type_Of_Govt_IDRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
       public IEnumerable<Type_Of_Govt_IdDTO> GetAll()
        {

            return Get().Select(x => new Type_Of_Govt_IdDTO { Type_Govt_ID = (int)x.Type_Govt_ID, Govt_Id_Type = x.Govt_Id_Type });
        }/*
        public IEnumerable<LookupDTO> GetAllasLookup()
        {

            return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
        }*/
        public Type_Of_Govt_IdDTO GetbyId(int id)
        {
            var cat = GetById(id);
            return new Type_Of_Govt_IdDTO
            {
                Govt_Id_Type = cat.Govt_Id_Type,
                Type_Govt_ID = (int)cat.Type_Govt_ID
            };
        }
        public async Task Post(Type_Of_Govt_IdDTO model)
        {

            var entity = new LookUp_Type_Of_Govt_ID()
            {
                Govt_Id_Type = model.Govt_Id_Type,
                //IsDeleted = false,
                //OrderBy = 0,
                //CreatedBy = Utils.GetUserId(_serviceProvider),
                //CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(Type_Of_Govt_IdDTO model)
        {
            var entity = GetById(model.Type_Govt_ID);
            if (entity != null)
            {
                entity.Govt_Id_Type = model.Govt_Id_Type;


                Put(entity);
            }
        }


        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
