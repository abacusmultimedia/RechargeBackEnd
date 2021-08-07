﻿using AutoMapper;
using CommonLayer.DTOs;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repos
{
   public class RewardRepo :RepositoryBase<Reward>, IRewardRepo
    {
        private readonly IServiceProvider _serviceProvider;
        public RewardRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            
            _serviceProvider = serviceProvider;
            
        }
        public IEnumerable<RewardDTO> GetAllReward()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => new RewardDTO {Id=x.Id ,Membership = x.Membership, MembershipNumber = x.MembershipNumber });
        }
        
        public RewardDTO GetRewardbyId(long id)
        {
            var cat = GetById(id);
            return new RewardDTO
            {
                Id=cat.Id,
                MembershipNumber = cat.MembershipNumber,
                Membership=cat.Membership
            };
        }

        public async Task PostReward(RewardDTO model)
        {
            var entity = new Reward()
            {
                EmployeeId=model.EmployeeId,
                RewardCheckBoxValue=model.RewardCheckBoxValue,
                Membership = model.Membership,
                MembershipNumber=model.MembershipNumber,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(RewardDTO model)
        {
            var entity = GetById(model.Id);
            if (entity != null)
            {
                entity.Id = model.Id;
                entity.Membership = model.Membership;
                entity.MembershipNumber = model.MembershipNumber;
                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
