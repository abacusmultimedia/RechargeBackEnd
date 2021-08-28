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
   public class Security_QuestionRepo :RepositoryBase<LookUp_Security_Question>, ISecurity_QuestionRepo
    {
        private readonly IServiceProvider _serviceProvider;
        public Security_QuestionRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
        }
         public IEnumerable<LookupDTO> GetAll()
         {
             return Get().Select(x => new LookupDTO { Key = (int)x.Question_ID, Value = x.Question_Title });
         }
        public SecurityQuestionDTO GetbyId(int id)
        {
            var cat = GetById(id);
            return new SecurityQuestionDTO
            {
                Question_Title = cat.Question_Title,
                Question_ID = (int)cat.Question_ID,
                Group = cat.Group
            };
        }
        public async Task Post(SecurityQuestionDTO model)
        {

            var entity = new LookUp_Security_Question()
            {
                Question_Title = model.Question_Title,
                Group =  model.Group,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(SecurityQuestionDTO model)
        {
            var entity = GetById(model.Question_ID);
            if (entity != null)
            {
                entity.Question_Title = model.Question_Title;
                entity.Group = model.Group;
                Put(entity);
            }
        }
        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
