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
        Task PostInitial(RC_Profile_BusinessInfor model);
        void SoftDelete(int id);
        void PutInitial(SignUPStage2BusinessDTO model);
        void PutStage2Peronal(string model);
        void PostPartnerBusinessinfo(Partner_BusinessInfo model);
    }
}
