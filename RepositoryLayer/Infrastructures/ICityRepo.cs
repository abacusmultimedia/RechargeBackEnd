using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ICityRepo : IRepositoryBase<LookUp_City>
    {
        //IEnumerable<LookupDTO> GetAllasLookup();
        IEnumerable<LookupDTO> GetAll();
        CityDTO GetbyId(long id);
        List<CityDTO> GetCityByState(long id);
        Task Post(CityDTO model);
        public void Put(CityDTO model);
        void SoftDelete(long id);
    }
}
