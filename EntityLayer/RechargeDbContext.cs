using EntityLayer.Entities; 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using static EntityLayer.Entities.Payroll;
using static EntityLayer.Entities.Rewards;
using static EntityLayer.Helpers.ConnectionStringHelper;

namespace EntityLayer
{
    public class RechargeDbContext : IdentityDbContext<ExtendedUser, ExtendedRole, string>
    {
        public RechargeDbContext(DbContextOptions<RechargeDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<SBI_Features> SBI_Features { get; set; }
        public DbSet<SBI_Project> SBI_Project { get; set; }
        public DbSet<RC_Profile_BusinessInfor> RC_Profile_BusinessInfor { get; set; }
        public DbSet<RC_Profile_BankingDetails> RC_Profile_BankingDetails { get; set; }
        public DbSet<RC_Profile_CardDetails> RC_Profile_CardDetails { get; set; }
        public DbSet<RC_Profile_Legal> RC_Profile_Legal { get; set; }
        public DbSet<Accounts_Transacation> Accounts_Transacation { get; set; }
        public DbSet<Accounts_childTransaction> Accounts_childTransaction { get; set; }
        public DbSet<Accounts_Ledger> Accounts_Ledger { get; set; }
        public DbSet<Accounts_LedgerGroup> Accounts_LedgerGroup { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<RC_Partners_Employees> RC_Partners_Employees { get; set; }
        public DbSet<LookUp_City> LookUp_City { get; set; }
        public DbSet<Lookup_Job_Title> Lookup_Job_Title { get; set; }
        public DbSet<LookUp_Country> LookUp_Country { get; set; }
        public DbSet<LookUp_State> LookUp_State { get; set; }
        public DbSet<LookUp_Security_Question> LookUp_Security_Questions { get; set; }
        public DbSet<LookUp_Type_Of_Govt_ID> LookUp_Type_Of_Govt_IDs { get; set; }
        public DbSet<RC_Profile_LoyalityMembership> RC_Profile_LoyalityMembership { get; set; }
        public DbSet<RC_Payroll_ServiceProvider> RC_Payroll_ServiceProvider { get; set; }
        public DbSet<RC_Payroll_Service> RC_Payroll_Service { get; set; }
        public DbSet<EmployeeServices> EmployeeServices { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<RC_Payment> RC_Payment { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Lookup_Reward> Lookup_Reward { get; set; }
        public DbSet<RC_Payroll_Service_Type> Service_Type { get; set; }
        public DbSet<RC_Payroll_ServiceProvider_Type> Service_Provider_Type { get; set; }

        ////     public DbSet<SBI_Project> SBI_Project { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.SerajBIConnectionString);
        }
    }
}
