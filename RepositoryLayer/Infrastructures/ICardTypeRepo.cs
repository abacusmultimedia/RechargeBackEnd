using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface ICardTypeRepo : IRepositoryBase<LookUp_CardType>
    {
        IEnumerable<LookupDTO> GetAll();
        CardTypeDTO GetbyId(long id);
        Task Post(CardTypeDTO model);
        void Put(CardTypeDTO model);
        void SoftDelete(long id);
    }
}
