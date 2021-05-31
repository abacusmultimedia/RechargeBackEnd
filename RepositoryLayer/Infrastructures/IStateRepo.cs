using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IStateRepo : IRepositoryBase<State>
    {
        //IEnumerable<LookupDTO> GetAllasLookup();
        //IEnumerable<LookupDTO> GetAll();
        StateDTO GetbyId(int id);
        Task Post(StateDTO model);
        public void Put(StateDTO model);
        void SoftDelete(int id);
    }
}
