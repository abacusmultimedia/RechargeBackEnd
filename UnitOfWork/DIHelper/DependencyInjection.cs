using CommonLayer.DTOs;
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
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ISubCategoryRepo, SubCategoryRepo>();
            services.AddScoped<IStateRepo, StateRepo>();
            services.AddScoped<ICountryRepo, CountryRepo>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<ISecurity_QuestionRepo, Security_QuestionRepo>();
            services.AddScoped<IType_Govt_IDRepo, Type_Of_Govt_IDRepo>();
            services.AddScoped<IPartners_EmployeesRepo, PartnersEmployeesRepo>();
            services.AddScoped<IService_ProviderRepo, Service_ProviderRepo>();
            services.AddScoped<IServicesRepo, ServicesRepo>();
            services.AddScoped<ILoyalityMembership, LoyalityMembershipRepo>();
            services.AddScoped<IConfigurationRepo, ConfigurationRepo>();
            services.AddScoped<IFormRepo, FormRepo>();
            services.AddScoped<IFieldsRepo, FieldsRepo>();
            services.AddScoped<IOptionRepo, OptionRepo>();
            services.AddScoped<IEmployeeServiceRepo, EmployeeServiceRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IAdvertisementRepo, AdvertisementRepo >();
            services.AddScoped<IJobTitleRepo, JobTitleRepo>();
            services.AddScoped<IRewardRepo, RewardRepo>();
            services.AddScoped<IServiceProviderTypeRepo, ServiceProviderTypeRepo>();
            services.AddScoped<IServiceTypeRepo, ServiceTypeRepo>();
            services.AddScoped<ILookupRewardRepo, LookupRewardRepo>();
            services.AddScoped<IFrequencyTypeRepo, FrequencyTypeRepo>();
            services.AddScoped<IBankTypeRepo, BankTypeRepo>();
            services.AddScoped<ICardTypeRepo, CardTypeRepo>();
            services.AddScoped<IAccountTypeRepo, AccountTypeRepo>();

            //services.AddScoped<>
            //Unit Of Work
            services.AddTransient<Seeder>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
