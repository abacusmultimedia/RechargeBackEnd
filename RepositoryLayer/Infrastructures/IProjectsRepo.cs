using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IProjectsRepo : IRepositoryBase<SBI_Project>
    {
        IEnumerable<ProjectDTO> GetAll();
        ProjectDTO GetProjectById(int id);
        Task Post(ProjectDTO model);
        void Put(ProjectDTO model);
        void SoftDelete(int id);
        void SendEmails(List<string> emailAddresses);

    }
}
