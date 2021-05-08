using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitOfWork;

namespace Casolve.Secure.Api.Controllers
{
    public class ValuesController : BaseController
    {
        public ValuesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
       

        [HttpGet]
        //[AllowAnonymous]
        public BaseResponse GetUsers()
        {
            return constructResponse(_unitOfWork.UsersRepository.Get());
        }
    }
}
