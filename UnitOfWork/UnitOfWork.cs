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
        //public IProjectAllowedToInvitRepo ProjectAllowedToInvitRepo => _serviceProvider.GetRequiredService<IProjectAllowedToInvitRepo>();
        //public IProjectFeatureRepo ProjectFeatureRepo => _serviceProvider.GetRequiredService<IProjectFeatureRepo>();
        //public IProjectGroupRepo ProjectGroupRepo => _serviceProvider.GetRequiredService<IProjectGroupRepo>();
        //public IProjectTagsRepo ProjectTagsRepo => _serviceProvider.GetRequiredService<IProjectTagsRepo>();
        //public IProjectTypeRepo ProjectTypeRepo => _serviceProvider.GetRequiredService<IProjectTypeRepo>();
        //public IProjectVisibilityTypeRepo ProjectVisibilityTypeRepo => _serviceProvider.GetRequiredService<IProjectVisibilityTypeRepo>();
         


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
