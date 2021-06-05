using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IStateRepo : IRepositoryBase<LookUp_State>
    {
        //IEnumerable<LookupDTO> GetAllasLookup();
        IEnumerable<StateDTO> GetAll();
        StateDTO GetbyId(long id);
        List<StateDTO> GetByCountryID(long id);
        Task Post(StateDTO model);
        public void Put(StateDTO model);
        void SoftDelete(long id);
    }
}
