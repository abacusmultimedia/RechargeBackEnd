using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ICountryRepo : IRepositoryBase<LookUp_Country>
    {
        //IEnumerable<LookupDTO> GetAllasLookup();
        IEnumerable<CountryDTO> GetAll();
        CountryDTO GetbyId(long id);
        Task Post(CountryDTO model);
        public void Put(CountryDTO model);
        IEnumerable<LookupDTO> GetAllasLookup();
        void SoftDelete(long id);

    }
}
