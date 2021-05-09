using CommonLayer.DTOs;
using AutoMapper;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace RepositoryLayer.Repos
{
    public class  Profile_BusinessInfoRepo : RepositoryBase<RC_Profile_BusinessInfor>, IProfile_BusinessInforRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public Profile_BusinessInfoRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo , RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<RC_Profile_BusinessInfor> GetAll()
        {
            return  Get(); 
        }
     
        public async Task Post(BusinessDetailsDTO model)
        {

            var entity = new RC_Profile_BusinessInfor()
            {
                Description = model.description,
                CreatedDate = DateTime.Now,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                IsDeleted = false,
                UserID = Utils.GetUserId(_serviceProvider),
                GSTNo = model.gst,
                BusinessName = model.businessName,
                //               BusinessRegCertificateImg = model.u
                //Logo
                // Category
                //
                //SubCategory
                Website = model.website,
                LoyaltyMembership = model.loyaltyMembership,
            };
            await Post(entity);    
        }
        public void Put(BusinessDetailsDTO model)
        {
            var entity = GetById(model.Id); 
            if (entity != null)
            {
                entity.BusinessName = model.businessName;
                entity.Description = model.description;
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.IsDeleted = false;
                entity.GSTNo = model.gst;
                entity.BusinessName = model.businessName;
                //               BusinessRegCertificateImg = model.u
                //Logo
                // Category
                //
                //SubCategory
                entity.Website = model.website;
                entity.LoyaltyMembership = model.loyaltyMembership;
                Put(entity);
            }
        }
 

        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }


    }
}
