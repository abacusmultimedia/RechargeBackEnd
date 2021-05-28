using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Infrastructures;
using UnitOfWork;

namespace Casolve.Secure.Api.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IUnitOfWork portalUnitOfWork ) : base(portalUnitOfWork)
        {

        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<BaseResponse> Login([FromBody] LoginDTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.ProcessLogin(model));
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<BaseResponse> LogoutAsync()
        {
            _unitOfWork.ExtendedUsersRepository.Logout();
            return constructResponse(await _unitOfWork.Save());
        }

       [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<BaseResponse> Register([FromBody] RegisterDTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Register(model));
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("GenerateForgotPasswordToken")]
        public async Task<BaseResponse> GenerateForgotPasswordToken(string email)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.GenerateForgotPasswordToken(email));
        }


       
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<BaseResponse> ResetPassword([FromBody] ResetPasswordDTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.ResetPassword(model));
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("ResetPasswordWithToken")]
        public async Task<BaseResponse> ResetPasswordWithToken(ResetPasswordDTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.ResetPasswordWithToken(model));
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("GetRoles")]
        public async Task<BaseResponse> GetRoles()
        {
            return constructResponse( _unitOfWork.ExtendedRolesRepository.GetRoles());
        }


#region Stages

        [HttpPost]
        [Route("Stage2BusinessDTOPost")]
        public async Task<BaseResponse> Stage2BusinessDTOPost([FromBody] SignUPStage2BusinessDTO model)
        {
            await _unitOfWork.ExtendedUsersRepository.Stage2BusinessPost(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPost]
        [Route("Stage2PersonalPost")]
        public async Task<BaseResponse> Stage2PersonalPost([FromBody]  SignUPStage2PersonalDTO model) 
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage2PersonalPost(model));
        }

        [HttpPost]
        [Route("Stage2PartnerPost")]
        public async Task<BaseResponse> Stage2PartnerPost([FromBody] SignUPStage2PartnerDTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage2PartnerPost(model));
        }

        [HttpPost]
        [Route("Stage3Post")]
        public async Task<BaseResponse> Stage3Post([FromBody] signUpstage3DTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage3Post(model));
        }

        [HttpPost]
        [Route("Stage4Post")]
        public async Task<BaseResponse> Stage4Post([FromBody] signUpstage4DTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage4Post(model));
        }

        [HttpPost]
        [Route("Stage5BusinessPost")]
        public async Task<BaseResponse> Stage5BusinessPost([FromBody] SignUPStage5BusinessDTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage5BusinessPost(model));
        }

        [HttpPost]
        [Route("Stage5PersonalPost")]
        public async Task<BaseResponse> Stage5PersonalPost([FromBody] SignUPStage5PersonalDTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage5PersonalPost(model));
        }

        [HttpPost]
        [Route("Stage5PartnerPost")]
        public async Task<BaseResponse> Stage5PartnerPost([FromBody] SignUPStage5PartnerDTO model)
        {
            return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage5PartnerPost(model));
        }
         
#endregion
        //[HttpPost]
        //[Route("Stage2BusinessDTOPost")]
        //public async Task<BaseResponse> ResetPassword([FromBody] SignUpStage2BusinessDTO model)
        //{
        //    return constructResponse(await _unitOfWork.ExtendedUsersRepository.Stage2BusinessPost(model));
        //}


    }
}
