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
    public class Profile_BusinessInfoRepo : RepositoryBase<RC_Profile_BusinessInfor>, IProfile_BusinessInforRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public Profile_BusinessInfoRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<RC_Profile_BusinessInfor> GetAll()
        {
            return Get();
        }

        public async Task Post(BusinessDetailsDTO model)
        {

            var entity = new RC_Profile_BusinessInfor()
            {
                Description = model.Description,
                CreatedDate = DateTime.Now,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                IsDeleted = false,
                UserID = Utils.GetUserId(_serviceProvider),
                GSTNo = model.Gst,
                BusinessName = model.BusinessName,
                Website = model.Website,
                LoyaltyMembership = model.LoyaltyMembership,
            };
            await Post(entity);
        }
        public async Task PostInitial(RC_Profile_BusinessInfor entity)
        {
            await Post(entity, true);
        }


        public void PutStage2Partner(SignUPStage2PartnerDTO model)
        {
            var userId = Utils.GetUserId(_serviceProvider);
            var entity = GetWithCondition(x => x.UserID == userId).FirstOrDefault();
            if (entity != null)
            {
                entity.BusinessName = model.BusinessName;
                entity.BusinessRegNumber = model.BusinessRegNumber;
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                Put(entity);
            }
        }
        public void Put(BusinessDetailsDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.BusinessName = model.BusinessName;
                entity.Description = model.Description;
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.IsDeleted = false;
                entity.GSTNo = model.Gst;
                entity.BusinessName = model.BusinessName;
                entity.Website = model.Website;
                entity.LoyaltyMembership = model.LoyaltyMembership;
                Put(entity);
            }
        }

        public void PutInitial(SignUPStage2BusinessDTO model)
        {
            var userId = Utils.GetUserId(_serviceProvider);
            var entity = GetWithCondition(x => x.UserID == userId).FirstOrDefault();
            if (entity != null)
            {
                entity.BusinessName = model.businessName;
                entity.Description = model.businessDescription;
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.BusinessName = model.businessName;
                entity.Website = model.website;
                entity.LoyaltyMembership = model.loyaltyMembership;
                entity.Category = model.category;
                entity.SubCategory = model.subCategory;
                Put(entity);
            }
        }

        public void PostPartnerBusinessinfo(Partner_BusinessInfo model)
        {
            var userId = Utils.GetUserId(_serviceProvider);
            var entity = GetWithCondition(x => x.UserID == userId).FirstOrDefault();
            if (entity != null)
            {
                entity.GSTNo = model.BusinessGSTNo;
                entity.BusinessRegNumber = model.UploadBusinessRegistrationNo;
                entity.BusinessRegCertificateImg = model.GvtIssuedPhotoID;
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                Put(entity);
            }
        }

        public void PutStage2Peronal(string model)
        {
            var userId = Utils.GetUserId(_serviceProvider);
            var entity = GetWithCondition(x => x.UserID == userId).FirstOrDefault();
            if (entity != null)
            {
                entity.LoyaltyMembership = model;
                Put(entity);
            }
        }


        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }


    }
}
