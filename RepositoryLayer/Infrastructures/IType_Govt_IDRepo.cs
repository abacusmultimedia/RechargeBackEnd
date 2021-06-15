using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IType_Govt_IDRepo : IRepositoryBase<LookUp_Type_Of_Govt_ID>
    {
        //IEnumerable<LookupDTO> GetAllasLookup();
        IEnumerable<LookupDTO> GetAll();
        Type_Of_Govt_IdDTO GetbyId(int id);
        Task Post(Type_Of_Govt_IdDTO model);
        public void Put(Type_Of_Govt_IdDTO model);
        void SoftDelete(int id);
    }
}
