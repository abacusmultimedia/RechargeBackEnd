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
        public IProfile_CardDetailsRepo CardDetailsRepo => _serviceProvider.GetRequiredService<IProfile_CardDetailsRepo>();
        public ICategoryRepo CategoryRepo => _serviceProvider.GetRequiredService<ICategoryRepo>();
        public ISubCategoryRepo SubCategoryRepo => _serviceProvider.GetRequiredService<ISubCategoryRepo>();
        public ITransactionRepo TransactionRepo => _serviceProvider.GetRequiredService<ITransactionRepo>();
        public IChildTransactionRepo ChildTransactionRepo => _serviceProvider.GetRequiredService<IChildTransactionRepo>();

        public ILoginsRepo LoginsRepository => _serviceProvider.GetRequiredService<ILoginsRepo>();
        public ICountryRepo CountryRepo => _serviceProvider.GetRequiredService<ICountryRepo>();
        public IStateRepo StateRepo => _serviceProvider.GetRequiredService<IStateRepo>();
        public ICityRepo CityRepo  => _serviceProvider.GetRequiredService<ICityRepo>(); 
        public ISecurity_QuestionRepo Security_QuestionRepo => _serviceProvider.GetRequiredService<ISecurity_QuestionRepo>(); 
        public IType_Govt_IDRepo Type_Govt_IDRepo => _serviceProvider.GetRequiredService<IType_Govt_IDRepo>();
        public ILedgerRepo LedgerRepo => _serviceProvider.GetRequiredService<ILedgerRepo>();
        public ILedgerGroupRepo LedgerGroupRepo => _serviceProvider.GetRequiredService<ILedgerGroupRepo>();
        public ILoyalityMembership LoyalityMembership => _serviceProvider.GetRequiredService<ILoyalityMembership>();
        public IPartners_EmployeesRepo Partners_EmployeesRepo => _serviceProvider.GetRequiredService<IPartners_EmployeesRepo>();
        public IServicesRepo ServicesRepo => _serviceProvider.GetRequiredService<IServicesRepo>();
       public IService_ProviderRepo Service_ProviderRepo => _serviceProvider.GetRequiredService<IService_ProviderRepo>();
        public IConfigurationRepo ConfigurationRepo => _serviceProvider.GetRequiredService<IConfigurationRepo>();
        public IFormRepo FormRepo => _serviceProvider.GetRequiredService<IFormRepo>();
        public IFieldsRepo FieldsRepo => _serviceProvider.GetRequiredService<IFieldsRepo>();
        public IOptionRepo OptionRepo => _serviceProvider.GetRequiredService<IOptionRepo>();
        public IEmployeeServiceRepo EmployeeService => _serviceProvider.GetRequiredService<IEmployeeServiceRepo>();
        public IPaymentRepo PaymentRepo => _serviceProvider.GetRequiredService<IPaymentRepo>();
        public IAdvertisementRepo AdvertisementRepo => _serviceProvider.GetRequiredService<IAdvertisementRepo>();
        public IJobTitleRepo JobTitleRepo => _serviceProvider.GetRequiredService<IJobTitleRepo>();
        public IRewardRepo RewardRepo => _serviceProvider.GetRequiredService<IRewardRepo>();
        public IServiceTypeRepo ServiceTypeRepo => _serviceProvider.GetRequiredService<IServiceTypeRepo>();
        public IServiceProviderTypeRepo ServiceProviderTypeRepo => _serviceProvider.GetRequiredService<IServiceProviderTypeRepo>();
        public ILookupRewardRepo LookupRewardRepo => _serviceProvider.GetRequiredService<ILookupRewardRepo>();
        public IFrequencyTypeRepo FrequencyTypeRepo => _serviceProvider.GetRequiredService<IFrequencyTypeRepo>();
        public IBankTypeRepo BankTypeRepo => _serviceProvider.GetRequiredService<IBankTypeRepo>();
        public ICardTypeRepo CardTypeRepo => _serviceProvider.GetRequiredService<ICardTypeRepo>();
        public IAccountTypeRepo AccountTypeRepo => _serviceProvider.GetRequiredService<IAccountTypeRepo>();


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
