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
        IEnumerable<CardDTO> GetByType(long type);
        void PutByType(CardDTO model);
        Task Post(CardDTO model);
        Task PostInitial(RC_Profile_CardDetails entity);
        void Put(CardDTO model);
        void SoftDelete(int id);



    }
}
