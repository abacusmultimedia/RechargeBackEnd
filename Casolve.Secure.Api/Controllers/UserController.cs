using Secure.Api.Controllers;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Secure.Api.Controllers
{
    public class UserController : BaseController
    {

        public UserController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }
        /// <summary>
        /// //  two forms with same name Business information to update // get info data 
        /// </summary> 
        [HttpGet]
        [Route("GetBusinessProfile")]
        public async Task<BaseResponse> GetBusinessProfile()
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage1ProfileBusinessInfoGet());
        }

        /// <summary>
        /// //  two forms with same name Business information to update // put data 
        /// </summary> 
        [HttpPut]
        [Route("UpdateBusinessProfile")]
        public async Task<BaseResponse> BusinessProfile([FromBody] ProfileBusinessInfoDTO model)
        {
            await _unitOfWork.ExtendedUsersRepository.Stage1ProfileBusinessInfoUpdate(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpGet]
        [Route("GetPhysicalAddress")]
        public async Task<BaseResponse> GetPhysicalAddress()
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage2ProfilePhysicalAddressGet());
        }

        [HttpPut]
        [Route("UpdatePhysicalAddress")]
        public async Task<BaseResponse> UpdatePhysicalAddress([FromBody] ProfilePhysicalAddressDTO model)
        {
            await _unitOfWork.ExtendedUsersRepository.Stage2ProfilePhysicalAddressUpdate(model);
            return constructResponse(await _unitOfWork.Save());

        }
        [HttpGet]
        [Route("GetProfileSecurityInfo")]
        public async Task<BaseResponse> GetProfileSecurityInfo()
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage4ProfileSecurityInfoGet());
        }
        [HttpPut]
        [Route("UpdateProfileSecurityInfoUpdate")]
        public async Task<BaseResponse> UpdateProfileSecurityInfoUpdate([FromBody] ProfileSecurityInfoDTO model)
        {
            await _unitOfWork.ExtendedUsersRepository.Stage4ProfileSecurityInfoUpdate(model);
            return constructResponse(await _unitOfWork.Save());
        }
    }
}
