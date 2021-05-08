using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        IUsersRepo UsersRepository { get; }

        ILoginsRepo LoginsRepository { get; }
        IExtendedUsersRepo ExtendedUsersRepository { get; }
        IExtendedRolesRepo ExtendedRolesRepository { get; }
        IProjectsRepo ProjectsRepository { get; }
        //IProjectAllowedToInvitRepo ProjectAllowedToInvitRepo { get; }
        //IProjectFeatureRepo ProjectFeatureRepo { get; }
        //IProjectGroupRepo ProjectGroupRepo { get; }
        //IProjectTagsRepo ProjectTagsRepo { get; }
        //IProjectTypeRepo ProjectTypeRepo { get; }
        //IProjectVisibilityTypeRepo ProjectVisibilityTypeRepo { get; }


        Task<bool> SaveChanges();
        Task<bool> Save();
    }
}
