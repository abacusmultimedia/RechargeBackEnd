using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IConfigurationRepo : IRepositoryBase<Configuration>
    {
        IEnumerable<ConfigurationDTO> GetAll();
        ConfigurationDTO GetbyId(long id);
        Task Post(ConfigurationDTO model);
        void Put(ConfigurationDTO model);
        void SoftDelete(long id);
    }
}
