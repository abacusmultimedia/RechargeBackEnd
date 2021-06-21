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
   public class LoyalityMembershipRepo : RepositoryBase<RC_Profile_LoyalityMembership>, ILoyalityMembership
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public LoyalityMembershipRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
        /*public IEnumerable<LookupDTO> GetAll()
        {

            return Get().Where(x => !x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.CityID, Value = x.CityName });
        }*/
         public IEnumerable<LookupDTO> GetAllasLookup()
         {

             return Get().Where(x=>!x.IsDeleted).Select(x => new LookupDTO { Key = (int)x.Id, Value = x.MembershipName });
         }
        public LoyalityMembershipDTO GetbyId(long id)
        {
            var cat = GetById(id);
            return new LoyalityMembershipDTO
            {
                Id = cat.Id,
                MembershipName =cat.MembershipName
            };
        }
       
        public async Task Post(LoyalityMembershipDTO model)
        {
            var entity = new RC_Profile_LoyalityMembership()
            {
                Id = model.Id,
                MembershipName = model.MembershipName,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(LoyalityMembershipDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Id = model.Id;
                entity.MembershipName = model.MembershipName;
                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
