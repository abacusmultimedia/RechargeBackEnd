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
        IProfile_BankingDetailsRepo profile_BankingDetailsRepo { get; } 
        IProfile_BusinessInforRepo Profile_BusinessInforRepo { get; }
        IProfile_LegalRepo profile_LegalRepo { get; }
        IProfile_CardDetailsRepo cardDetailsRepo { get; }

        Task<bool> SaveChanges();
        Task<bool> Save();
    }
}
