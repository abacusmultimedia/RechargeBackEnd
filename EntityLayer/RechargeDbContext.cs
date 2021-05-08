﻿using EntityLayer.Entities; 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
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




   ////     public DbSet<SBI_Project> SBI_Project { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.SerajBIConnectionString);
        }
    }
}
