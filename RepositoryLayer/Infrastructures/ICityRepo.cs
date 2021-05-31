using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ICityRepo : IRepositoryBase<City>
    {
        //IEnumerable<LookupDTO> GetAllasLookup();
        //IEnumerable<LookupDTO> GetAll();
        CityDTO GetbyId(int id);
        Task Post(CityDTO model);
        public void Put(CityDTO model);
        void SoftDelete(int id);
    }
}
