using CommonLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Secure.Api.Controllers
{
    public class PaymentController : BaseController
    {
        public PaymentController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }

        [HttpGet]
        [Route("GetPayment")]
        public async Task<BaseResponse> GetPayment()
        {
            return constructResponse(_unitOfWork.PaymentRepo.GetAll());
        }

        [HttpPost]
        [Route("PaymentPost")]
        public async Task<BaseResponse> PaymentPost([FromBody] PaymentDTO model)
        {
            await _unitOfWork.PaymentRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("PaymentUpdate")]
        public async Task<BaseResponse> PaymentUpdate([FromBody] PaymentDTO model)
        {
            _unitOfWork.PaymentRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("PaymentDelete/{id}")]
        public async Task<BaseResponse> PaymentDelete(int id)
        {
            _unitOfWork.PaymentRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpGet]
        [Route("GetPaymentbyId/{id}")]
        public BaseResponse PaymentbyId(int id)
        {
            return constructResponse(_unitOfWork.PaymentRepo.GetbyId(id));
        }

    }
}
