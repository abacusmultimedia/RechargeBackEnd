using EntityLayer;
using EntityLayer.Entities;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Repos
{
    public class LoginsRepo : RepositoryBase<Login>, ILoginsRepo
    {
        private readonly IServiceProvider _serviceProvider;

        public LoginsRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
