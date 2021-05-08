using CommonLayer.DTOs;
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
    public class FeatureRepo : RepositoryBase<SBI_Features>, IFeatureRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IExtendedUsersRepo _extendedUsersRepo;
        public FeatureRepo(IServiceProvider serviceProvider, IExtendedUsersRepo extendedUsersRepo , RechargeDbContext context) : base(context)
        {
            _extendedUsersRepo = extendedUsersRepo;
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        public IEnumerable<SBI_Features> GetAll()
        {
            return  Get(); 
        }
     
        public async Task Post(FeatureDTO model)
        {

            var entity = new SBI_Features()
            {
                SBI_Features_Descriptions = model.Features_Descriptions,
                SBI_Features_Title= model.Features_Title
                
            };
            await Post(entity);    
        }
        public void Put(FeatureDTO model)
        {
            var entity = GetById(model.Id); 
            if (entity != null)
            {
                entity.SBI_Features_Title = model.Features_Title;
                entity.SBI_Features_Descriptions = model.Features_Descriptions;                
                Put(entity);
            }
        }
 

        public void SoftDelete(int id)
        {
            GetById(id).IsDeleted = true;
        }


    }
}
