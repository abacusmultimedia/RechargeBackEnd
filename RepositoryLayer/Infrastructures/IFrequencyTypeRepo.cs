using CommonLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Payment;

namespace RepositoryLayer.Infrastructures
{
    public interface IFrequencyTypeRepo : IRepositoryBase<LookUp_Frequency>
    {
        IEnumerable<LookupDTO> GetAll();
        FrequencyTypeDTO GetbyId(long id);
        Task Post(FrequencyTypeDTO model);
        void Put(FrequencyTypeDTO model);
        void SoftDelete(long id);
    }
}
