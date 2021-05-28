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
    public class TransactionController : BaseController
    {
        public TransactionController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }
        #region Transaction
        [HttpGet]
        [Route("GetTransactions")]
        public BaseResponse GetRoleAsLookups()
        {
            return  constructResponse(  _unitOfWork.TransactionRepo.GetAll());
        }

        [HttpPost]
        [Route("TransactionPost")]
        public async Task<BaseResponse> TransactionPost([FromBody] ParentTransactionDTO model)
        {
            await _unitOfWork.TransactionRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("TransactionUpdate")]
        public async Task<BaseResponse> TransactionUpdate([FromBody] ParentTransactionDTO model)
        {
            _unitOfWork.TransactionRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("TransactionDelete/{id}")]
        public async Task<BaseResponse> TransactionDelete(int id)
        {
            _unitOfWork.TransactionRepo.Delete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpGet]
        [Route("GetTransactionById/{id}")]
        public BaseResponse TransactionbyId(int id)
        {
            return constructResponse(_unitOfWork.TransactionRepo.GetById(id));
        }

        #endregion
    }
}
