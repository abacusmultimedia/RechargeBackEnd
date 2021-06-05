using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ISecurity_QuestionRepo  : IRepositoryBase<LookUp_Security_Question>
    {
        //IEnumerable<LookupDTO> GetAllasLookup();
        IEnumerable<SecurityQuestionDTO> GetAll();
        SecurityQuestionDTO GetbyId(int id);
        Task Post(SecurityQuestionDTO model);
        public void Put(SecurityQuestionDTO model);
        void SoftDelete(int id);
    }
}
