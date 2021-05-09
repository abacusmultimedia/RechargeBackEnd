using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IProfile_CardDetailsRepo : IRepositoryBase<RC_Profile_CardDetails>
    {
        IEnumerable<RC_Profile_CardDetails> GetAll();
        Task Post(CardDTO model);
        void Put(CardDTO model);
        void SoftDelete(int id);



    }
}
