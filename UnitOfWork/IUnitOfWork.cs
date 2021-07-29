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
        IProfile_CardDetailsRepo CardDetailsRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        ISubCategoryRepo SubCategoryRepo { get; }
        ITransactionRepo TransactionRepo { get; }
        IChildTransactionRepo ChildTransactionRepo { get; }
        IStateRepo StateRepo { get; }
        ICountryRepo CountryRepo { get; }
        ICityRepo CityRepo { get; }
        ISecurity_QuestionRepo Security_QuestionRepo { get; }
        IType_Govt_IDRepo Type_Govt_IDRepo { get; }
        ILedgerRepo LedgerRepo { get; }
        ILedgerGroupRepo LedgerGroupRepo { get;}
        ILoyalityMembership LoyalityMembership { get; }
        //ISecurity_QuestionRepo Security_Question{ get; }
        //IType_Govt_IDRepo Type_Govt_ID{ get; }
        IPartners_EmployeesRepo Partners_EmployeesRepo { get; }
        IServicesRepo ServicesRepo { get; }
        IService_ProviderRepo Service_ProviderRepo { get; }
        IConfigurationRepo ConfigurationRepo { get; }
        IFormRepo FormRepo { get; }
        IFieldsRepo FieldsRepo { get; }
        IOptionRepo OptionRepo { get; }
        IEmployeeServiceRepo EmployeeService { get; }
        Task<bool> SaveChanges();
        Task<bool> Save();
    }
}
