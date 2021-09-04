using CommonLayer.DTOs;
using CommonLayer.Helpers;
using EntityLayer;
using EntityLayer.Entities;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repos
{
    public class AccountTypeRepo : RepositoryBase<Lookup_AccountType>, IAccountTypeRepo
    {

            private readonly IServiceProvider _serviceProvider;
            public AccountTypeRepo(IServiceProvider serviceProvider, RechargeDbContext context) : base(context)
            {
                _serviceProvider = serviceProvider;
            }
            public IEnumerable<LookupDTO> GetAll()
            {
                return Get().Select(x => new LookupDTO { Key = (int)x.ID, Value = x.Accountname });
            }

            public AccountTypeDTO GetbyId(long id)
            {
                var entity = GetById(id);
                return new AccountTypeDTO
                {
                    ID = entity.ID,
                    Accountname = entity.Accountname,
                };
            }
            public async Task Post(AccountTypeDTO model)
            {
                var entity = new Lookup_AccountType()
                {
                    ID = model.ID,
                    Accountname = model.Accountname,
                    IsDeleted = false,
                    CreatedBy = Utils.GetUserId(_serviceProvider),
                    CreatedDate = DateTime.Now,
                };
                await Post(entity);
            }
            public void Put(AccountTypeDTO model)
            {
                var entity = GetById(model.ID);
                if (entity != null)
                {
                    entity.ID = model.ID;
                    entity.Accountname = model.Accountname;
                    Put(entity);
                }
            }
            public void SoftDelete(long id)
            {
                GetById(id).IsDeleted = true;
            }

        }
    }

