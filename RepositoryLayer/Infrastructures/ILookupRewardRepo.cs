using CommonLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Rewards;

namespace RepositoryLayer.Infrastructures
{
    public interface ILookupRewardRepo : IRepositoryBase<Lookup_Reward>
    {
        IEnumerable<LookupDTO> GetAll();
        LookupRewardDTO GetbyId(long id);
        Task Post(LookupRewardDTO model);
        void Put(LookupRewardDTO model);
        void SoftDelete(long id);
    }
}
