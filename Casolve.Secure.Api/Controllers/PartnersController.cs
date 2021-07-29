using  Secure.Api.Controllers;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Secure.Api.Controllers
{
    public class PartnersController : BaseController
    {
        public PartnersController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }

        [HttpGet]
        [Route("PartnersEmployeesGet")]
        public async Task<BaseResponse> PartnersEmployeesGet()
        {
            return constructResponse(_unitOfWork.Partners_EmployeesRepo.GetAll());
        }

        [HttpPost]
        [Route("PartnersEmployeesPost")]
        public async Task<BaseResponse> PartnersEmployeesPost([FromBody] PartnersEmployeesDTO model)
        {
            await _unitOfWork.Partners_EmployeesRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPost]
        [Route("EmployeeServicesPost")]
        public async Task<BaseResponse> EmployeeServicesPost([FromBody] EmployeewithServicesDTO model)
        {
            await _unitOfWork.Partners_EmployeesRepo.PostWithService(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("PartnersEmployeesUpdate")]
        public async Task<BaseResponse> PartnersEmployeesUpdate([FromBody] PartnersEmployeesDTO model)
        {
            _unitOfWork.Partners_EmployeesRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("PartnersEmployeesDelete/{id}")]
        public async Task<BaseResponse> PartnersEmployeesDelete(long id)
        {
            _unitOfWork.Partners_EmployeesRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpGet]
        [Route("GetEmployeeExist")]
        public async Task<BaseResponse> GetEmployeeExist(long id)
        {
            return constructResponse(_unitOfWork.Partners_EmployeesRepo.IsExist(id));
        }
        
    }
}
