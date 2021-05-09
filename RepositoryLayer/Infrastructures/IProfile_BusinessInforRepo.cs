using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IProfile_BusinessInforRepo : IRepositoryBase<RC_Profile_BusinessInfor>
    {
        IEnumerable<RC_Profile_BusinessInfor> GetAll();
        Task Post(BusinessDetailsDTO model);
        void Put(BusinessDetailsDTO model);
        void SoftDelete(int id);



    }
}
