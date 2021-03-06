using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using static EntityLayer.Entities.Payroll;
using static EntityLayer.Entities.Rewards;
using static EntityLayer.Entities.Payment;

namespace UnitOfWork.DataSeeder
{
    public class Seeder
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly RechargeDbContext _context;
        private readonly RoleManager<ExtendedRole> _roleManager;
        private readonly UserManager<ExtendedUser> _userManager;
        private static string createdById;
        public Seeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService<RechargeDbContext>();
            _roleManager = _serviceProvider.GetRequiredService<RoleManager<ExtendedRole>>();
            _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        }
        public async Task Seed()
        {
            await _context.Database.MigrateAsync();
            await AddRoles();
            await AddSuperAdmin();
            /// AddFeatures();
        }
        private async Task AddRoles()
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                var roles = new List<ExtendedRole>()
                {
                     new ExtendedRole(){ Name = "Admin", Description = "Super User"},
                     new ExtendedRole(){ Name = "Personal", Description = "Personal" },
                     new ExtendedRole(){ Name = "Business", Description = "Business" },
                     new ExtendedRole(){ Name = "Bank", Description = "Provide Investor , and Security" },
                     new ExtendedRole(){ Name = "Investor", Description = "Provide Funding for Project Implementation and development" },
                     new ExtendedRole(){ Name = "Partner", Description = "Project Partner" },
                };

                foreach (var item in roles)
                    await _roleManager.CreateAsync(item);
                AddLookups();
            }
        }
        //private async Task AddFeatures()
        //{

        //    if (!await _context.SBI_Features.AnyAsync())
        //    {
        //        var features = new List<SBI_Features>()
        //        {
        //             new SBI_Features(){ SBI_Features_Title = "Tasks", SBI_Features_Descriptions = "Super User"},
        //             new SBI_Features(){ SBI_Features_Title = "Calendar", SBI_Features_Descriptions = "Work with students " },
        //             new SBI_Features(){ SBI_Features_Title = "Drive", SBI_Features_Descriptions = "Project and idia creator User" },
        //             new SBI_Features(){ SBI_Features_Title = "Chat", SBI_Features_Descriptions = "Provide Investor , and Security" },
        //             new SBI_Features(){ SBI_Features_Title = "Conversations", SBI_Features_Descriptions = "Provide Funding for Project Implementation and development" },
        //             new SBI_Features(){ SBI_Features_Title = "PhotoGallery", SBI_Features_Descriptions = "Project Evaluator" },
        //             new SBI_Features(){ SBI_Features_Title = "Wiki", SBI_Features_Descriptions = "Project Evaluator" },
        //             new SBI_Features(){ SBI_Features_Title = "Applications", SBI_Features_Descriptions = "Project Evaluator" },
        //             new SBI_Features(){ SBI_Features_Title = "KnowledgeBase", SBI_Features_Descriptions = "Project Evaluator" },

        //        };

        //        foreach (var item in features)
        //        {
        //            _context.SBI_Features.Add(item);
        //            _context.SaveChanges();
        //        }
        //    }
        //}
        private async Task AddSuperAdmin()
        {
            if (!await _userManager.Users.AnyAsync())
            {
                var user = new ExtendedUser()
                {
                    FirstName = "Super",
                    LastName = "Admin",
                    Email = "superadmin@yopmail.com",
                    TenantId = "0",
                    UserName = "superadmin",
                    EmailConfirmed = true,
                    MemberStatus = true
                };

                await _userManager.CreateAsync(user, "Test@0000");
                await _userManager.AddToRoleAsync(user, "Admin");

                createdById = _userManager.FindByEmailAsync("superadmin@yopmail.com").Result.Id;
                await AddUsers();
            }
        }
        private async Task AddUsers()
        {
            var user = new ExtendedUser()
            {
                FirstName = "Khalid",
                LastName = "Hussain",
                Email = "std@yopmail.com",
                TenantId = "0",
                UserName = "Personal",
                EmailConfirmed = true,
                MemberStatus = true
            };
            await _userManager.CreateAsync(user, "Test@0000");
            await _userManager.AddToRoleAsync(user, "Personal");
            createdById = _userManager.FindByEmailAsync("std@yopmail.com").Result.Id;
        }
        private void AddLookups()
        {
            Category c = new Category()
            {
                OrderBy = 1,
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
                Name = "First",
            };
            _context.Add(c);
            _context.SaveChanges();

            SubCategory subCat = new SubCategory()
            {
                OrderBy = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                CreatedBy = "Seeder",
                Name = "Frst Sub Cat",
                ParentID = 1
            };
            _context.Add(subCat);
            _context.SaveChanges();

            Accounts_LedgerGroup acGroup = new Accounts_LedgerGroup()
            {
                CreatedBy = "Seeder",
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            _context.Add(acGroup);
            _context.SaveChanges();

            Accounts_Ledger leger = new Accounts_Ledger()
            {
                IsDeleted = false,
                Title = "First",
                openingBalance = 90.00,
                ParentLedgerGroupID = 1,
                StartDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                CreatedBy = "Seeder",
            };
            _context.Add(leger);
            _context.SaveChanges();

            LookUp_Country lookUp_Country = new LookUp_Country()
            {
                CountryName = "Pakistan",
                IsDeleted = false
            };
            _context.Add(lookUp_Country);
            _context.SaveChanges();

            LookUp_State lookUp_State = new LookUp_State()
            {
                StateName = "Punjab",
                CountryID = 1,
            };
            _context.Add(lookUp_State);
            _context.SaveChanges();

            LookUp_City lookUp_City = new LookUp_City()
            {
                CityName = "Rawalpindi",
                IsDeleted = false,
                StateID = 1,
            };
            _context.Add(lookUp_City);
            _context.SaveChanges();

            RC_Payroll_ServiceProvider_Type payroll_ServiceProvider_Type = new RC_Payroll_ServiceProvider_Type()
            {
                Name = "Silver",
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(payroll_ServiceProvider_Type);
            _context.SaveChanges();

            RC_Payroll_ServiceProvider payroll_ServiceProvider = new RC_Payroll_ServiceProvider()
            {
                Title = "Silver",
                Type = 1,
                Discription = "Silver",
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(payroll_ServiceProvider);
            _context.SaveChanges();

            RC_Payroll_Service_Type payroll_Service_Type = new RC_Payroll_Service_Type()
            {
                Name = "Gold",
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(payroll_Service_Type);
            _context.SaveChanges();

            RC_Payroll_Service payroll_Service = new RC_Payroll_Service()
            {
                Title = "Gold",
                Type = 1,
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(payroll_Service);
            _context.SaveChanges();

            Lookup_Reward lookup_Reward = new Lookup_Reward()
            {
                RewardName = "Zong",
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(lookup_Reward);
            _context.SaveChanges();

            Lookup_Job_Title lookup_Job_Title = new Lookup_Job_Title()
            {
                Title = "Manager",
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(lookup_Job_Title);
            _context.SaveChanges();

            LookUp_Security_Question lookUp_Security_Question = new LookUp_Security_Question()
            {
                Question_Title = "What is your favourite colour?",
                Group = 1,
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(lookUp_Security_Question);
            _context.SaveChanges();

            LookUp_Security_Question lookUp_Security_Question1 = new LookUp_Security_Question()
            {
                Question_Title = "What is your favourite season?",
                Group = 2,
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(lookUp_Security_Question1);
            _context.SaveChanges();
            LookUp_Bank lookUp_Bank = new LookUp_Bank()
            {
                BankName = "Mezan Bank",
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(lookUp_Bank);
            _context.SaveChanges();

            LookUp_Frequency lookUp_Frequency = new LookUp_Frequency()
            {
                Name = "abc",
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(lookUp_Frequency);
            _context.SaveChanges();

            LookUp_CardType lookUp_CardType = new LookUp_CardType()
            {
                CardName = "Visa",
                IsDeleted = false,
                CreatedBy = "Seeder", 
                CreatedDate = DateTime.Now,
            };
            _context.Add(lookUp_CardType);
            _context.SaveChanges();
            Lookup_AccountType lookup_AccountType = new Lookup_AccountType()
            {
                Accountname = "Current",
                IsDeleted = false,
                CreatedBy = "Seeder",
                CreatedDate = DateTime.Now,
            };
            _context.Add(lookup_AccountType);
            _context.SaveChanges();

        }
    }
}
