
using CommonLayer;
using CommonLayer.DTOs;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static CommonLayer.Constants;

namespace RepositoryLayer.Repos
{
    public class ExtendedRolesRepo : RepositoryBase<ExtendedUser>, IExtendedRolesRepo
    {
        private readonly IServiceProvider _serviceProvider;


        public ExtendedRolesRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
            //  _mapper = _serviceProvider.GetRequiredService<IMapper>();
            ///  _blobUploader = _serviceProvider.GetRequiredService<IBlobUploader>();
        }
 
        public  List<ExtendedRole> GetRoles()
        {
            return  _serviceProvider.GetRequiredService<RoleManager<ExtendedRole>>().Roles.ToList();
        }
         
    }
}