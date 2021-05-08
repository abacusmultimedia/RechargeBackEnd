using EntityLayer;
using EntityLayer.Entities;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Repos
{
    public class UsersRepo : RepositoryBase<User>, IUsersRepo
    {
        public UsersRepo(RechargeDbContext context) : base(context)
        {

        }
    }
}
