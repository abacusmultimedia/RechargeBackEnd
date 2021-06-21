using Casolve.Secure.Api.Controllers;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Secure.Api.Controllers
{
    public class CardDetailsController : BaseController
    {
        public CardDetailsController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }
      /*  [HttpGet]
        [Route("GetCategoryAsLookup")]
        public async Task<BaseResponse> GetRoleAsLookups()
        {
            return constructResponse(_unitOfWork.CategoryRepo.GetAll());
        }*/

        [HttpGet]
        [Route("GetByType")]
        public async Task<BaseResponse> GetByType(long type)
        {
            return constructResponse(_unitOfWork.CardDetailsRepo.GetByType(type));
        }
        [HttpPut]
        [Route("PaymentTypeUpdate")]
        public async Task<BaseResponse> PaymentTypeUpdate([FromBody] CardDTO model)
        {
            _unitOfWork.CardDetailsRepo.PutByType(model);
            return constructResponse(await _unitOfWork.Save());
        }
    }
}
