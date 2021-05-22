using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IProfile_LegalRepo : IRepositoryBase<RC_Profile_Legal>
    {
        IEnumerable<RC_Profile_Legal> GetAll();
        Task Post(LegalDTO model);
        Task PostInitial(RC_Profile_Legal model);
        void Put(LegalDTO model);
        void SoftDelete(int id);



    }
}
