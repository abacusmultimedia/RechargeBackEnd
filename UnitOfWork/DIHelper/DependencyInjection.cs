using CommonLayer.Helpers;
using CommonLayer.Services.EmailService;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Infrastructures;
using RepositoryLayer.Repos;
using UnitOfWork.DataSeeder;

namespace UnitOfWork.DIHelper
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            //DbContext
            services.AddDbContext<RechargeDbContext>();
            services.AddIdentity<ExtendedUser, ExtendedRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<RechargeDbContext>()
                .AddDefaultTokenProviders();

            //Custom Services
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<IExtendedUsersRepo, ExtendedUsersRepo>();
            services.AddScoped<IExtendedRolesRepo, ExtendedRolesRepo>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<ILoginsRepo, LoginsRepo>();
            services.AddScoped<IProjectsRepo, ProjectsRepo>(); 
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddScoped<IChildTransactionRepo, ChildTransactionRepo>();
            services.AddScoped<ILedgerRepo, LedgerRepo>();
            services.AddScoped<ILedgerGroupRepo, LedgerGroupRepo>();
            services.AddScoped<IChildTransactionRepo, ChildTransactionRepo>();
            services.AddScoped<IProfile_BankingDetailsRepo, Profile_BankingDetailsRepo>();
            services.AddScoped<IProfile_BusinessInforRepo, Profile_BusinessInfoRepo>();
            services.AddScoped<IProfile_CardDetailsRepo, Profile_CardDetailsRepo>();
            services.AddScoped<IProfile_LegalRepo, Profile_LegalRepo>();



            //services.AddScoped<IProjectAllowedToInvitRepo, ProjectAllowedToInvitRepo>();
            //services.AddScoped<IProjectFeatureRepo, ProjectFeatureRepo>();
            //services.AddScoped<IProjectGroupRepo, ProjectGroupRepo>();
            //services.AddScoped<IProjectTagsRepo, ProjectTagsRepo>();
            //services.AddScoped<IProjectTypeRepo, ProjectTypeRepo>();
            //services.AddScoped<IProjectVisibilityTypeRepo, ProjectVisibilityTypeRepo>();

            //services.AddScoped<>
            //Unit Of Work
            services.AddTransient<Seeder>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
