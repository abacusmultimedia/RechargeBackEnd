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

    }
}
