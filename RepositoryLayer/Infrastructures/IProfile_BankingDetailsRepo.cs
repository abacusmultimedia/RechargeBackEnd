using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IProfile_BankingDetailsRepo : IRepositoryBase<RC_Profile_BankingDetails>
    {
        IEnumerable<RC_Profile_BankingDetails> GetAll();
        Task Post(BankDetailsDTO model);
        void Put(BankDetailsDTO model);
        void SoftDelete(int id);
        Task PostInitial(RC_Profile_BankingDetails entity);
        void PutInitial(signUpstage4DTO model);
    }
}
