using AutoMapper;
using CommonLayer.DTOs;
using EntityLayer.Entities;
//using EntityLayer.LicenseDbContext.Entities;
//using EntityLayer.PortalDbContext.Entities;
using System.Security.Claims;
using static CommonLayer.Constants;

namespace CommonLayer.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //// Project
            CreateMap<SBI_Project, ProjectDTO>().
                ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.SBI_Project_ProjectName)).
                ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.SBI_Project_Description)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SBI_Project_Key))
               .ForMember(dest => dest.whoCanInvite, opt => opt.MapFrom(src => src.SBI_Project_CanInviteMoreId))

                //  ForMember(dest => dest.whoCanInvite, opt => opt.MapFrom(src => src.))


                //                ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.SBI_Project_owner)).  
                ;









            //    ForMember(dest => dest.BillingPlanName, opt => opt.MapFrom(src => src.BillingPlan.Name));
            //CreateMap<SubscriptionPlanDTO, SubscriptionPlans>();

            ////Payment History
            //CreateMap<PaymentHistory, PaymentHistoryDTO>().
            //    ForMember(dest => dest.SubscriptionPlanName, opt => opt.MapFrom(src => src.SubscriptionPlan.Name)).
            //    ForMember(dest => dest.SubscriptionPlanBillingType, opt => opt.MapFrom(src => src.SubscriptionPlan.BillingPlan.Name));
            //CreateMap<PaymentHistoryDTO, PaymentHistory>();

            ////Stripe Configuration
            //CreateMap<StripeConfiguration, StripeConfigurationsDTO>().ReverseMap();

            ////Company
            //CreateMap<Company, CompanyDTO>().
            //    ForMember(dest => dest.SubscriptionPlanName, opt => opt.MapFrom(src => src.SubscriptionPlan.Name));
            //CreateMap<CompanyDTO, Company>();

            ////Company
            //CreateMap<Contact, ContactsDTO>()
            //.ReverseMap();

            ////Contact
            //CreateMap<Contact, ContactsDTO>().
            //  ForMember(dest => dest.ContactTypeName, opt => opt.MapFrom(src => src.ContactType.Name)).
            //  ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Citites.Name)).
            //  ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.Citites.State.Name)).
            //  ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.Citites.State.Id)).
            //  ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Citites.State.Country.Id)).
            //  ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Citites.State.Country.Name)).
            //  ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Languages.Name));
            //CreateMap<ContactsDTO, Contact>();

            ////Case
            //CreateMap<Case, CaseDTO>().
            //  ForMember(dest => dest.CaseStatusName, opt => opt.MapFrom(src => src.CaseStatus.Name)).
            //  ForMember(dest => dest.CaseTypeName, opt => opt.MapFrom(src => src.CaseType.Name)).
            //  ForMember(dest => dest.ContactClientName, opt => opt.MapFrom(src => src.ContactClient.FirstName)).
            //  ForMember(dest => dest.CountryCurrentName, opt => opt.MapFrom(src => src.CountryCurrent.Name)).
            //  ForMember(dest => dest.CountryToImmigrateName, opt => opt.MapFrom(src => src.CountryToImmigrate.Name)).
            //  ForMember(dest => dest.TeamMemberName, opt => opt.MapFrom(src => src.TeamMember.FirstName + " " + src.TeamMember.LastName)).
            //  ForMember(dest => dest.CaseAssigneeName, opt => opt.MapFrom(src => src.CaseAssignee.FirstName + " " + src.CaseAssignee.LastName));
            //CreateMap<CaseDTO, Case>();

            ////Case Additional Information
            //CreateMap<CaseAdditionalInformation, CaseAdditionalInformationDTO>().
            //  ForMember(dest => dest.CityLocationName, opt => opt.MapFrom(src => src.CityLocation.Name)).
            //  ForMember(dest => dest.CountryOfCitizenshipName, opt => opt.MapFrom(src => src.CountryOfCitizenship.Name)).
            //  ForMember(dest => dest.ProvinceId, opt => opt.MapFrom(src => src.CityLocation.State.Id)).
            //  ForMember(dest => dest.CountryOfResidenceId, opt => opt.MapFrom(src => src.CityLocation.State.Country.Id)).
            //  ForMember(dest => dest.MaritalStatusName, opt => opt.MapFrom(src => src.MaritalStatus.Name)).
            //  ForMember(dest => dest.CountryOfResidenceName, opt => opt.MapFrom(src => src.CityLocation.State.Country.Name)).
            //  ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.CityLocation.State.Name));
            //CreateMap<CaseAdditionalInformationDTO, CaseAdditionalInformation>();

            ////Case Additional Information
            //CreateMap<CaseImmigrationHistory, CaseImmigrationHistoryDTO>().ReverseMap();

            ////Case School Detail
            //CreateMap<CaseSchoolDetail, CaseSchoolDetailDTO>().
            // ForMember(dest => dest.PreferredCourseName, opt => opt.MapFrom(src => src.PreferredCourse.Name)).
            // ForMember(dest => dest.PreferredCountryId, opt => opt.MapFrom(src => src.PreferredProvince.Country.Id)).
            // ForMember(dest => dest.PreferredProvinceName, opt => opt.MapFrom(src => src.PreferredProvince.Name));
            //CreateMap<CaseSchoolDetailDTO, CaseSchoolDetail>();

            ////Case Educational History
            //CreateMap<CaseEducationalHistory, CaseEducationalHistoryDTO>().ReverseMap();

            ////Case Passport Detail
            //CreateMap<CasePassportDetail, CasePassportDetailDTO>().ReverseMap();

            ////Case Dependents
            //CreateMap<CaseDependent, CaseDependentDTO>().ReverseMap();

            ////Case Primary Parent Detail
            //CreateMap<CasePrimaryParentDetail, CasePrimaryParentDetailDTO>().ReverseMap();

            ////Case Spouse Parent Detail
            //CreateMap<CaseSpouseParentDetail, CaseSpouseParentDetailDTO>().ReverseMap();

            ////Case Siblings
            //CreateMap<CaseSibling, CaseSiblingDTO>().ReverseMap();

            ////Case Siblings
            //CreateMap<CaseApplicantDeclaration, CaseApplicantDeclarationDTO>().ReverseMap();

            ////Case Work in canada
            //CreateMap<CaseWorkInCanada, CaseWorkInCanadaDTO>().ReverseMap();

            ////Case Finance
            //CreateMap<CaseFinance, CaseFinanceDTO>().ReverseMap();

            ////Case Travel History  DestinationStateId
            //CreateMap<CaseTravelHistory, CaseTravelHistoryDTO>().
            // ForMember(dest => dest.DestinationStateId, opt => opt.MapFrom(src => src.DestinationCity.State.Id)).
            // ForMember(dest => dest.DestinationCountryId, opt => opt.MapFrom(src => src.DestinationCity.State.Country.Id)).
            // ForMember(dest => dest.DestinationCityName, opt => opt.MapFrom(src => src.DestinationCity.Name)).
            // ForMember(dest => dest.DestinationStateName, opt => opt.MapFrom(src => src.DestinationCity.State.Name)).
            // ForMember(dest => dest.DestinationCountryName, opt => opt.MapFrom(src => src.DestinationCity.State.Country.Name));
            //CreateMap<CaseTravelHistoryDTO, CaseTravelHistory>();

            ////Case Employment History
            //CreateMap<CaseEmploymentHistory, CaseEmploymentHistoryDTO>().ReverseMap();

            ////Case Language Exam
            //CreateMap<CaseLanguageExam, CaseLanguageExamDTO>().
            // ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Language.Name)).
            // ForMember(dest => dest.IeltsExamName, opt => opt.MapFrom(src => src.IELTSExam.Name));
            //CreateMap<CaseLanguageExamDTO, CaseLanguageExam>().ReverseMap();

            ////Case Emergency Contact
            //CreateMap<CaseEmergencyContact, CaseEmergencyContactDTO>().
            // ForMember(dest => dest.RelationshipName, opt => opt.MapFrom(src => src.Relationship.Name));
            //CreateMap<CaseEmergencyContactDTO, CaseEmergencyContact>().ReverseMap();

            ////Case Notes
            //CreateMap<CaseNoteDTO, CaseNote>().ReverseMap();

            ////Case Tasks
            //CreateMap<CaseTask, CaseTaskDTO>().
            // ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name)).
            // ForMember(dest => dest.PriorityName, opt => opt.MapFrom(src => src.Priority.Name)).
            // ForMember(dest => dest.AssignedToName, opt => opt.MapFrom(src => src.AssignedTo.FirstName + " " + src.AssignedTo.LastName)).
            // ForMember(dest => dest.AssignedByName, opt => opt.MapFrom(src => src.AssignedBy.FirstName + " " + src.AssignedBy.LastName));
            //CreateMap<CaseTaskDTO, CaseTask>();

            ////Case Retainer Schedules
            //CreateMap<CaseRetainerSchedule, CaseRetainerScheduleDTO>().
            //  ForMember(dest => dest.CaseName, opt => opt.MapFrom(src => src.Case.CaseNumber)).
            //  ForMember(dest => dest.DueOnName, opt => opt.MapFrom(src => src.DueOn.FirstName + " " + src.DueOn.LastName));
            //CreateMap<CaseRetainerScheduleDTO, CaseRetainerSchedule>();

            ////Case Documents
            //CreateMap<CaseDocument, CaseDocumentDTO>().
            //  ForMember(dest => dest.CaseName, opt => opt.MapFrom(src => src.Case.CaseNumber)).
            //  ForMember(dest => dest.DocumentTypeName, opt => opt.MapFrom(src => src.DocumentType.Name));
            //CreateMap<CaseDocumentDTO, CaseDocument>();

            ////Case Forms
            //CreateMap<CaseForm, CaseFormDTO>().
            //  ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).
            //  ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Language.Name));
            //CreateMap<CaseFormDTO, CaseForm>();

            ////Case User
            //CreateMap<Case, CaseUserDTO>().
            //  ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ContactClient.FirstName)).
            //  ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ContactClient.LastName)).
            //  ForMember(dest => dest.CaseStatus, opt => opt.MapFrom(src => src.CaseStatus.Name)).
            //  ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactClient.Email)).
            //  ForMember(dest => dest.CaseType, opt => opt.MapFrom(src => src.CaseType.Name)).
            //  ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ContactClient.BlobURI)).
            //  ForMember(dest => dest.ImmigrationStatusName, opt => opt.MapFrom(src => src.CaseImmigrationDepartmentStatus.Status.Name));

            ////Case Transaction
            //CreateMap<CaseTransaction, CaseTransactionDTO>().
            //  ForMember(dest => dest.CaseName, opt => opt.MapFrom(src => src.Case.CaseNumber)).
            //  ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name)).
            //  ForMember(dest => dest.InvoiceNo, opt => opt.MapFrom(src => src.CaseInvoice.InvoiceNo));
            //CreateMap<CaseTransactionDTO, CaseTransaction>();

            ////Case Invoice 
            //CreateMap<CaseInvoice, CaseInvoiceDTO>().
            //  ForMember(dest => dest.CaseName, opt => opt.MapFrom(src => src.Case.CaseNumber)).
            //  ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Contact.FirstName + " " + src.Contact.LastName)).
            //  ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name));
            //CreateMap<CaseInvoiceDTO, CaseInvoice>();

            ////Case Invoice Expense
            //CreateMap<CaseInvoiceExpenseDTO, CaseInvoiceExpense>().ReverseMap();

            ////Case Invoice Flat Fee
            //CreateMap<CaseInvoiceFlatFeeDTO, CaseInvoiceFlatFee>().ReverseMap();

            ////Case Invoice Retainer
            //CreateMap<CaseInvoiceRetainerDTO, CaseInvoiceRetainer>().ReverseMap();

            ////Case Invoice Time Entry
            //CreateMap<CaseInvoiceTimeEntryDTO, CaseInvoiceTimeEntry>().ReverseMap();

            ////Case Immigration Department Status
            //CreateMap<CaseImmigrationDepartmentStatus, CaseImmigrationDepartmentStatusDTO>().
            //     ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name));
            //CreateMap<CaseImmigrationDepartmentStatusDTO, CaseImmigrationDepartmentStatus>();

            ////Bank Account 
            //CreateMap<BankAccount, BankAccountDTO>().
            //   ForMember(dest => dest.BankAccountTypeName, opt => opt.MapFrom(src => src.BankAccountType.Name));
            //CreateMap<BankAccountDTO, BankAccount>();

            //CreateMap<ExtendedRole, RoleDTO>()
            //   .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name));

            //CreateMap<ExtendedUser, TeamMemberDTO>().
            //    ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.Citites.State.Id)).
            //    ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Citites.State.Country.Id));

            ////Commission
            //CreateMap<Commission, CommissionDTO>().
            //   ForMember(dest => dest.CaseTypeName, opt => opt.MapFrom(src => src.CaseType.Name)).
            //   ForMember(dest => dest.Case, opt => opt.MapFrom(src => src.Case.CaseNumber));

            ////User Personal Settings
            //CreateMap<ExtendedUser, UserPersonalSettingsDTO>().
            //   ForMember(dest => dest.PhoneNo, opt => opt.MapFrom(src => src.PhoneNumber)).
            //   ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.BlobURI));

            ////User Company Settings
            //CreateMap<UserCompanySettings, UserCompanySettingsDTO>().ReverseMap();

            ////User Accounting Settings
            //CreateMap<UserAccountingSettings, UserAccountingSettingsDTO>().ReverseMap();

            ////User Company
            //CreateMap<UserCompany, UserCompanyDTO>().
            //    ForMember(dest => dest.ProvinceId, opt => opt.MapFrom(src => src.City.StateId)).
            //    ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.City.State.CountryId));
        }
    }
}