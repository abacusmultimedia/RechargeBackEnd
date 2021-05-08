using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace Casolve.Secure.Api.Controllers
{
    public class LookUpController : BaseController
    {
        public LookUpController(IUnitOfWork portalUnitOfWork ) : base(portalUnitOfWork)
        {

        }



        //[HttpGet]
        //[AllowAnonymous]
        //[Route("ProjectType")]
        //public async Task<BaseResponse> GetRoleAsLookups()
        //{
        //    return constructResponse(await _unitOfWork.ExtendedUsersRepository.Register());
        //}

    }
}
