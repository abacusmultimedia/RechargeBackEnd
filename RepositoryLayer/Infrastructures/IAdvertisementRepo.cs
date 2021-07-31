using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IAdvertisementRepo : IRepositoryBase<Advertisement>
    {
        IEnumerable<AdvertisementDTO> GetAll();
        AdvertisementDTO GetbyId(long id);
        Task Post(AdvertisementDTO model);
        void Put(AdvertisementDTO model);
        void SoftDelete(long id);
    }
}
