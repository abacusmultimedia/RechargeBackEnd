using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IFeatureRepo : IRepositoryBase<SBI_Features>
    {
        IEnumerable<SBI_Features> GetAll();
        Task Post(FeatureDTO model);
        public void Put(FeatureDTO model);

        void SoftDelete(int id);
 

    }
}
