using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IJobTitleRepo : IRepositoryBase<Lookup_Job_Title>
    {
        IEnumerable<LookupDTO> GetAll();
        LookupDTO GetbyId(int id);
        Task Post(LookupDTO model);
        void Put(LookupDTO model);
        void SoftDelete(int id);
    }
}
