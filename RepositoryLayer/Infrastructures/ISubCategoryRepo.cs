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
        IEnumerable<SubCategory> GetAll();
        Task Post(SubCategoryDTO model);
        void Put(SubCategoryDTO model);
        void SoftDelete(int id);
        SubCategoryDTO GetbyId(int id);
}
}
