using CommonLayer.DTOs;
using CommonLayer.Helpers;
using EntityLayer;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.Entities.Rewards;

namespace RepositoryLayer.Repos
{
    public class LookupRewardRepo : RepositoryBase<Lookup_Reward>, ILookupRewardRepo
    {
        private readonly IServiceProvider _serviceProvider;
        public LookupRewardRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;        
        }
        public IEnumerable<LookupDTO> GetAll()
        {
            return Get().Where(x => !x.IsDeleted).Select(x => 
            new LookupDTO { Key = (int)x.RewardId, Value = x.RewardName });
        }

        public LookupRewardDTO GetbyId(long id)
        {
            var entity = GetById(id);
            return new LookupRewardDTO
            {
                RewardId = entity.RewardId,
                RewardName = entity.RewardName
            };
        }
        public async Task Post(LookupRewardDTO model)
        {
            var entity = new Lookup_Reward()
            {
                RewardName = model.RewardName,
                IsDeleted = false,
                CreatedBy = Utils.GetUserId(_serviceProvider),
                CreatedDate = DateTime.Now,
            };
            await Post(entity);
        }
        public void Put(LookupRewardDTO model)
        {
            var entity = GetById(model.RewardId);
            if (entity != null)
            {
                entity.RewardName = model.RewardName;

                Put(entity);
            }
        }
        public void SoftDelete(long id)
        {
            GetById(id).IsDeleted = true;
        }
    }
}
