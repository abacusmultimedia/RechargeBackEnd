using CommonLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Secure.Api.Controllers
{
    public class ConfigurationController : BaseController
    {
        public ConfigurationController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }
        [HttpGet]
        [Route("GetConfigurationAsLookup")]
        public async Task<BaseResponse> GetConfigurationAsLookup()
        {
            return constructResponse(_unitOfWork.ConfigurationRepo.GetAll());
        }
        [HttpPost]
        [Route("ConfigurationPost")]
        public async Task<BaseResponse> ConfigurationPost([FromBody] ConfigurationDTO model)
        {
            await _unitOfWork.ConfigurationRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("ConfigurationUpdate")]
        public async Task<BaseResponse> ConfigurationUpdate([FromBody] ConfigurationDTO model)
        {
            _unitOfWork.ConfigurationRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpDelete("ConfigurationDelete/{id}")]
        public async Task<BaseResponse> ConfigurationDelete(int id)
        {
            _unitOfWork.ConfigurationRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpGet]
        [Route("ConfigurationbyId/{id}")]
        public BaseResponse ConfigurationbyId(int id)
        {
            return constructResponse(_unitOfWork.ConfigurationRepo.GetbyId(id));
        }
    }
}
