using CommonLayer.DTOs;
using EntityLayer.Entities;
using RepositoryLayer.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface ILoyalityMembership : IRepositoryBase<RC_Profile_LoyalityMembership>
    {
       IEnumerable<LookupDTO> GetAllasLookup();
        LoyalityMembershipDTO GetbyId(long id);
        Task Post(LoyalityMembershipDTO model);
        void Put(LoyalityMembershipDTO model);
        void SoftDelete(long id);
    }
}
