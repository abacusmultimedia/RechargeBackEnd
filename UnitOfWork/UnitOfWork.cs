using EntityLayer;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Infrastructures;
using System;
using System.Threading.Tasks;
using static CommonLayer.Constants;

namespace UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly RechargeDbContext _context;

        public IUsersRepo UsersRepository { get; }
        public IExtendedUsersRepo ExtendedUsersRepository => _serviceProvider.GetRequiredService<IExtendedUsersRepo>();
        public IExtendedRolesRepo ExtendedRolesRepository => _serviceProvider.GetRequiredService<IExtendedRolesRepo>();
        public IProjectsRepo ProjectsRepository => _serviceProvider.GetRequiredService<IProjectsRepo>();
        public IProfile_BankingDetailsRepo profile_BankingDetailsRepo => _serviceProvider.GetRequiredService<IProfile_BankingDetailsRepo>();
        public IProfile_BusinessInforRepo Profile_BusinessInforRepo => _serviceProvider.GetRequiredService<IProfile_BusinessInforRepo>();
        public IProfile_LegalRepo profile_LegalRepo => _serviceProvider.GetRequiredService<IProfile_LegalRepo>();
        public IProfile_CardDetailsRepo cardDetailsRepo => _serviceProvider.GetRequiredService<IProfile_CardDetailsRepo>();




        public ILoginsRepo LoginsRepository => _serviceProvider.GetRequiredService<ILoginsRepo>();
        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService<RechargeDbContext>();

            //Get Required Services
            UsersRepository = _serviceProvider.GetRequiredService<IUsersRepo>();
        }


        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Save()
        {
            try
            {
                if (await _context.SaveChangesAsync() > 0)
                    OtherConstants.isSuccessful = true;
                else
                    OtherConstants.isSuccessful = false;

                return OtherConstants.isSuccessful;
            }
            catch (Exception ex)
            {
                return OtherConstants.isSuccessful;
            }

        }
    }
}
