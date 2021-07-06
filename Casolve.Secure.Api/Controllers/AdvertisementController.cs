using CommonLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Secure.Api.Controllers
{
    public class AdvertisementController : BaseController
    {
        public AdvertisementController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }
        #region Form
        [HttpGet]
        [Route("GetForm")]
        public async Task<BaseResponse> GetForm()
        {
            return constructResponse(_unitOfWork.FormRepo.GetAll());
        }
        [HttpPost]
        [Route("FormPost")]
        public async Task<BaseResponse> FormPost([FromBody] FormDTO model)
        {
            await _unitOfWork.FormRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("FormUpdate")]
        public async Task<BaseResponse> FormUpdate([FromBody] FormDTO model)
        {
            _unitOfWork.FormRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpDelete("FormDelete/{id}")]
        public async Task<BaseResponse> FormDelete(int id)
        {
            _unitOfWork.FormRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpGet]
        [Route("FormbyId/{id}")]
        public BaseResponse FormbyId(int id)
        {
            return constructResponse(_unitOfWork.FormRepo.GetbyId(id));
        }
        #endregion

        #region Fields
        [HttpGet]
        [Route("GetFields")]
        public async Task<BaseResponse> GetFields()
        {
            return constructResponse(_unitOfWork.FieldsRepo.GetAll());
        }
        [HttpPost]
        [Route("FieldsPost")]
        public async Task<BaseResponse> FieldsPost([FromBody] FieldsDTO model)
        {
            await _unitOfWork.FieldsRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("FieldsUpdate")]
        public async Task<BaseResponse> FieldsUpdate([FromBody] FieldsDTO model)
        {
            _unitOfWork.FieldsRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpDelete("FieldsDelete/{id}")]
        public async Task<BaseResponse> FieldsDelete(int id)
        {
            _unitOfWork.FieldsRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpGet]
        [Route("FieldsbyId/{id}")]
        public BaseResponse FieldsbyId(int id)
        {
            return constructResponse(_unitOfWork.FieldsRepo.GetbyId(id));
        }
        #endregion

        #region Options
        [HttpGet]
        [Route("GetOptions")]
        public async Task<BaseResponse> GetOptions()
        {
            return constructResponse(_unitOfWork.OptionRepo.GetAll());
        }
        [HttpPost]
        [Route("OptionsPost")]
        public async Task<BaseResponse> OptionsPost([FromBody] OptionsDTO model)
        {
            await _unitOfWork.OptionRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("OptionsUpdate")]
        public async Task<BaseResponse> OptionsUpdate([FromBody] OptionsDTO model)
        {
            _unitOfWork.OptionRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpDelete("OptionsDelete/{id}")]
        public async Task<BaseResponse> OptionsDelete(int id)
        {
            _unitOfWork.OptionRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpGet]
        [Route("OptionsbyId/{id}")]
        public BaseResponse OptionsbyId(int id)
        {
            return constructResponse(_unitOfWork.OptionRepo.GetbyId(id));
        }
        #endregion
    }
}
