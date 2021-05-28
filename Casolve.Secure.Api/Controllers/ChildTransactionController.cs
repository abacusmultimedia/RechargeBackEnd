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
    public class ChildTransactionController : BaseController
    {
        public ChildTransactionController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }
        #region ChildTransaction
        [HttpGet]
        [Route("GetTransactions")]
        public BaseResponse GetRoleAsLookups()
        {
            return constructResponse(_unitOfWork.ChildTransactionRepo.GetAll());
        }

        [HttpPost]
        [Route("ChildTransactionPost")]
        public async Task<BaseResponse> ChildTransactionPost([FromBody] TransactionDTO model)
        {
            await _unitOfWork.ChildTransactionRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("ChildTransactionUpdate")]
        public async Task<BaseResponse> ChildTransactionUpdate([FromBody] TransactionDTO model)
        {
            _unitOfWork.ChildTransactionRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("ChildTransactionDelete/{id}")]
        public async Task<BaseResponse> ChildTransactionDelete(int id)
        {
            _unitOfWork.ChildTransactionRepo.Delete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpGet]
        [Route("GetChildTransactionById/{id}")]
        public BaseResponse GetChildTransactionbyId(int id)
        {
            return constructResponse(_unitOfWork.ChildTransactionRepo.GetById(id));
        }

        #endregion
    }
}
