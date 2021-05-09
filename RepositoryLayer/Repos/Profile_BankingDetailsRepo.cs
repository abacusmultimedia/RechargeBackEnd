﻿using CommonLayer.DTOs;
using AutoMapper;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace RepositoryLayer.Repos
{
    public class  Profile_BankingDetailsRepo : RepositoryBase<RC_Profile_BankingDetails>, IProfile_BankingDetailsRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public Profile_BankingDetailsRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo , RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<RC_Profile_BankingDetails> GetAll()
        {
            return  Get(); 
        }
     
        public async Task Post(BankDetails model)
        {

            var entity = new RC_Profile_BankingDetails()
            {
 
            };
            await Post(entity);    
        }
        public void Put(BankDetails model)
        {
            var entity = GetById(model.Id); 
            if (entity != null)
            {
 
                Put(entity);
            }
        }
 

        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }


    }
}
