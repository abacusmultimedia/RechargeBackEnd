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
   public class Security_QuestionRepo :RepositoryBase<LookUp_Security_Question>, ISecurity_QuestionRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public Security_QuestionRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo, RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }
         public IEnumerable<SecurityQuestionDTO> GetAll()
         {

             return Get().Select(x => new SecurityQuestionDTO { Question_ID = (int)x.Question_ID, Question_Title = x.Question_Title });
         }
        /*
         public IEnumerable<LookupDTO> GetAllasLookup()
         {

             return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Name });
         }*/
        public SecurityQuestionDTO GetbyId(int id)
        {
            var cat = GetById(id);
            return new SecurityQuestionDTO
            {
                Question_Title = cat.Question_Title,
                Question_ID = (int)cat.Question_ID
            };
        }
        public async Task Post(SecurityQuestionDTO model)
        {

            var entity = new LookUp_Security_Question()
            {
                Question_Title = model.Question_Title,
                //IsDeleted = false,
                //OrderBy = 0,
                //CreatedBy = Utils.GetUserId(_serviceProvider),
                //CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(SecurityQuestionDTO model)
        {
            var entity = GetById(model.Question_ID);
            if (entity != null)
            {
                entity.Question_Title = model.Question_Title;


                Put(entity);
            }
        }


        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
