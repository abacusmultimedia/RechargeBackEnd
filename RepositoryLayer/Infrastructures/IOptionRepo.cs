using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IOptionRepo : IRepositoryBase<Options>
    {
        IEnumerable<OptionsDTO> GetAll();
        OptionsDTO GetbyId(long id);
        List<OptionsDTO> GetOptionsByFieldId(long Id);
        Task Post(OptionsDTO model);
        void Put(OptionsDTO model);
        void SoftDelete(long id);
    }
}
