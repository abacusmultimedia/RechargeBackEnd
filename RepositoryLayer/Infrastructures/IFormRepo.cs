using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IFormRepo : IRepositoryBase<Form>
    {
        IEnumerable<FormDTO> GetAll();
        FormDTO GetbyId(long id);
        Task Post(FormDTO model);
        void Put(FormDTO model);
        void SoftDelete(long id);
    }
}
