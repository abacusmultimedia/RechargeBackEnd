using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IFieldsRepo : IRepositoryBase<Fields>
    {
        IEnumerable<FieldsDTO> GetAll();
        FieldsDTO GetbyId(long id);
        Task Post(FieldsDTO model);
        void Put(FieldsDTO model);
        void SoftDelete(long id);
    }
}
