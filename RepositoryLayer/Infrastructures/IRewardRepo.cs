using CommonLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
   public interface IRewardRepo :IRepositoryBase<Reward>
    {
        IEnumerable<RewardDTO> GetAllReward();
        RewardDTO GetRewardbyId(long id);
        Task PostReward(RewardDTO model);
        void Put(RewardDTO model);
        void SoftDelete(long id);
    }
}
