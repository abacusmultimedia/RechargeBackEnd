using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ICountryRepo : IRepositoryBase<Country>
    {
        //IEnumerable<LookupDTO> GetAllasLookup();
        //IEnumerable<LookupDTO> GetAll();
        CountryDTO GetbyId(int id);
        Task Post(CountryDTO model);
        public void Put(CountryDTO model);
        void SoftDelete(int id);
    }
}
