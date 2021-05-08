using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;
using static CommonLayer.Constants;

namespace Casolve.Secure.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected BaseResponse constructResponse(object response)
        {
            BaseResponse result = null;
            try
            {
                result = new BaseResponse()
                {
                    dynamicResult = response,
                    isSuccessfull = OtherConstants.isSuccessful,
                    statusCode = response != null ? 200 : 500,
                    messageType = OtherConstants.messageType,
                    message = OtherConstants.responseMsg,
                    errorMessage = OtherConstants.responseMsg
                };
            }

            catch (Exception er)
            {
                string erMsg = er.Message;
            }

            return result;
        }
    }
}
