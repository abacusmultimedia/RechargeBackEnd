using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;

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




    }
}
