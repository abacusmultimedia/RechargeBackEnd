using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ICategoryRepo : IRepositoryBase<Category>
    {
        IEnumerable<LookupDTO> GetAllasLookup();
        IEnumerable<LookupDTO> GetAll();
        CategoryDTO GetbyId(int id);
        Task Post(CategoryDTO model);
        public void Put(CategoryDTO model);
        void SoftDelete(long id);

    }
}
