using CommonLayer.DTOs;
using EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IExtendedRolesRepo : IRepositoryBase<ExtendedUser>
    {
 
        List<ExtendedRole> GetRoles();
     
 
    }
}
