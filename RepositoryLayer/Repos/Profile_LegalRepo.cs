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
    public class Profile_LegalRepo : RepositoryBase<RC_Profile_Legal>, IProfile_LegalRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public Profile_LegalRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<RC_Profile_Legal> GetAll()
        {
            return Get();
        }

        public async Task Post(LegalDTO model)
        {

            var entity = new RC_Profile_Legal()
            {
                PhotoId = model.PhotoId,
                Country = model.Country,
                PhotIDNumber = model.PhotIDNumber,
                ImageURL = model.ImageURL,
                SecurityQuestion1 = model.SecurityQuestion1,
                SecurityQuestion2 = model.SecurityQuestion2,
                Answer1 = model.Answer1,
                Answer2 = model.Answer2,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now

            };
            await Post(entity);
        }

        public async Task PostInitial(RC_Profile_Legal model)
        {
            await Post(model,true);
        }

        public void Put(LegalDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.PhotoId = model.PhotoId;
                entity.Country = model.Country;
                entity.PhotIDNumber = model.PhotIDNumber;
                entity.ImageURL = model.ImageURL;
                entity.SecurityQuestion1 = model.SecurityQuestion1;
                entity.SecurityQuestion2 = model.SecurityQuestion2;
                entity.Answer1 = model.Answer1;
                entity.Answer2 = model.Answer2;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.ModifiedDate = DateTime.Now;
                Put(entity);
            }
        }
        public void PutInitial(SignUPStage5PersonalDTO model , string url)
        {
            var entity = GetWithCondition(x=>x.User.Id == Utils.GetUserId(_serviceProvider)).FirstOrDefault();
            if (entity != null)
            {
                entity.PhotoId = model.GovtPhotoIDNo;
                entity.Country = model.countryIssueId;
                entity.PhotIDNumber = model.GovtPhotoIDNo;
                entity.ImageURL  =  url==null?"":url;
                entity.SecurityQuestion1 = model.SecurityQuestion1;
                entity.SecurityQuestion2 = model.SecurityQuestion2;
                entity.Answer1 = model.SecurityAnswer1;
                entity.Answer2 = model.SecurityAnswer2;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.ModifiedDate = DateTime.Now;
                Put(entity);
            }
        }

        public void PutSecurityQsandAs(QsAndAsDTO model)
        {
            var entity = GetWithCondition(x => x.User.Id == Utils.GetUserId(_serviceProvider)).FirstOrDefault();
            if (entity != null)
            { 
                entity.SecurityQuestion1 = model.SecurityQuestion1;
                entity.SecurityQuestion2 = model.SecurityQuestion2;
                entity.Answer1 = model.SecurityAnswer1;
                entity.Answer2 = model.SecurityAnswer2;
                entity.ModifiedBy = Utils.GetUserId(_serviceProvider);
                entity.ModifiedDate = DateTime.Now;
                Put(entity);
            }
        }


        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }


    }
}
