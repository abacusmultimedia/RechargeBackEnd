using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface ISubCategoryRepo : IRepositoryBase<SubCategory>
    { 
        IEnumerable<LookupDTO> GetAll();
        Task Post(SubCategoryDTO model);
        void Put(SubCategoryDTO model);
        void SoftDelete(long id);
        SubCategoryDTO GetbyId(int id);
}
}
