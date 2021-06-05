﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace Casolve.Secure.Api.Controllers
{
    public class LookUpController : BaseController
    {
        public LookUpController(IUnitOfWork portalUnitOfWork) : base(portalUnitOfWork)
        {

        }
        #region Category
        [HttpGet]
        [Route("GetCategoryAsLookup")]
        public async Task<BaseResponse> GetRoleAsLookups()
        {
            return constructResponse(_unitOfWork.CategoryRepo.GetAll());
        }

        [HttpPost]
        [Route("CategoryPost")]
        public async Task<BaseResponse> CategoryPost([FromBody] CategoryDTO model)
        {
            await _unitOfWork.CategoryRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("CategoryUpdate")]
        public async Task<BaseResponse> CategoryUpdate([FromBody] CategoryDTO model)
        {
            _unitOfWork.CategoryRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("CategoryDelete/{id}")]
        public async Task<BaseResponse> CategoryDelete(int id)
        {
            _unitOfWork.CategoryRepo.Delete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpPost]
        [Route("CategoryIdPost/{id}")]
        public BaseResponse CategorybyId(int id)
        {
            return constructResponse(_unitOfWork.CategoryRepo.GetbyId(id));
        }

        #endregion
        #region SubCategory
        [HttpGet]
        [Route("GetSubCategoryAsLookup")]
        public async Task<BaseResponse> GetSubCategoryAsLookup()
        {
            return constructResponse(_unitOfWork.SubCategoryRepo.GetAll());
        }

        [HttpPost]
        [Route("SubCategoryPost")]
        public async Task<BaseResponse> SubCategoryPost([FromBody] SubCategoryDTO model)
        {
            await _unitOfWork.SubCategoryRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("SubCategoryUpdate")]
        public async Task<BaseResponse> SubCategoryUpdate([FromBody] SubCategoryDTO model)
        {
            _unitOfWork.SubCategoryRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("SubCategoryDelete/{id}")]
        public async Task<BaseResponse> SubCategoryDelete(int id)
        {
            _unitOfWork.SubCategoryRepo.Delete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpPost]
        [Route("SubCategoryIdPost/{id}")]
        public BaseResponse SubCategorybyId(int id)
        {
            return constructResponse(_unitOfWork.SubCategoryRepo.GetbyId(id));
        }


        /// City Lookup 
        // Country Lookup 
        ///  State Lookup 
        ///  type Of Govt ID
        ///  Security Questions ID

        #endregion
        //[HttpPost] 
        //[Route("SubCategoryPost")]
        //public async Task<BaseResponse> SubCategoryPost([FromBody] SubCategoryDTO model)
        //{
        //    return constructResponse(await _unitOfWork.ExtendedUsersRepository.SubCategoryPost(model));
        //}

        /* [HttpGet]
         [AllowAnonymous]
         [Route("ProjectType")]
         public async Task<BaseResponse> GetRoleAsLookups()
         {
             return constructResponse(await _unitOfWork.ExtendedUsersRepository.Register());
         }*/
        #region State
        [HttpGet]
        [Route("GetStateAsLookup")]
        public async Task<BaseResponse> GetStateAsLookup()
        {
            return constructResponse(_unitOfWork.StateRepo.GetAll());
        }

        [HttpPost]
        [Route("StatePost")]
        public async Task<BaseResponse> StatePost([FromBody] StateDTO model)
        {
            await _unitOfWork.StateRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("StateUpdate")]
        public async Task<BaseResponse> StateUpdate([FromBody] StateDTO model)
        {
            _unitOfWork.StateRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("StateDelete/{id}")]
        public async Task<BaseResponse> StateDelete(long id)
        {
            _unitOfWork.StateRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpPost]
        [Route("StateIdPost/{id}")]
        public BaseResponse StatebyId(int id)
        {
            return constructResponse(_unitOfWork.StateRepo.GetbyId(id));
        }
        [HttpPost]
        [Route("GetStatesByCountryId/{id}")]
        public BaseResponse GetStatebyId(long id)
        {
            return constructResponse(_unitOfWork.StateRepo.GetByCountryID(id));
        }
        #endregion

        #region Country
        [HttpGet]
        [Route("GetCountryAsLookup")]
        public async Task<BaseResponse> GetCountryAsLookup()
        {
            return constructResponse(_unitOfWork.CountryRepo.GetAll());
        }

        [HttpPost]
        [Route("CountryPost")]
        public async Task<BaseResponse> CountryPost([FromBody] CountryDTO model)
        {
            await _unitOfWork.CountryRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("CountryUpdate")]
        public async Task<BaseResponse> CountryUpdate([FromBody] CountryDTO model)
        {
            _unitOfWork.CountryRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("CountryDelete/{id}")]
        public async Task<BaseResponse> CountryDelete(long id)
        {
            _unitOfWork.CountryRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpPost]
        [Route("CountryIdPost/{id}")]
        public BaseResponse CountrybyId(int id)
        {
            return constructResponse(_unitOfWork.CountryRepo.GetbyId(id));
        }

        #endregion

        #region City
        [HttpGet]
        [Route("GetCityAsLookup")]
        public async Task<BaseResponse> GetCityAsLookup()
        {
            return constructResponse(_unitOfWork.CityRepo.GetAll());
        }

        [HttpPost]
        [Route("CityPost")]
        public async Task<BaseResponse> CityPost([FromBody] CityDTO model)
        {
            await _unitOfWork.CityRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("CityUpdate")]
        public async Task<BaseResponse> CityUpdate([FromBody] CityDTO model)
        {
            _unitOfWork.CityRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("CityDelete/{id}")]
        public async Task<BaseResponse> CityDelete(long id)
        {
            _unitOfWork.CityRepo.SoftDelete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpPost]
        [Route("CityIdPost/{id}")]
        public BaseResponse CitybyId(int id)
        {
            return constructResponse(_unitOfWork.CityRepo.GetbyId(id));
        }
        [HttpPost]
        [Route("GetCityByStateID/{id}")]
        public BaseResponse GetCityByStateID(long id)
        {
            return constructResponse(_unitOfWork.CityRepo.GetCityByState(id));
        }
        #endregion
        #region SecurityQuestion
        [HttpGet]
        [Route("GetSecurityQuestionAsLookup")]
        public async Task<BaseResponse> GetSecurityQuestionAsLookup()
        {
            return constructResponse(_unitOfWork.Security_QuestionRepo.GetAll());
        }

        [HttpPost]
        [Route("SecurityQuestionPost")]
        public async Task<BaseResponse> SecurityQuestionPost([FromBody] SecurityQuestionDTO model)
        {
            await _unitOfWork.Security_QuestionRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("SecurityQuestionUpdate")]
        public async Task<BaseResponse> SecurityQuestionUpdate([FromBody] SecurityQuestionDTO model)
        {
            _unitOfWork.Security_QuestionRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("SecurityQuestionDelete/{id}")]
        public async Task<BaseResponse> SecurityQuestion(int id)
        {
            _unitOfWork.Security_QuestionRepo.Delete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpPost]
        [Route("SecurityQuestionIdPost/{id}")]
        public BaseResponse SecurityQuestionbyId(int id)
        {
            return constructResponse(_unitOfWork.Security_QuestionRepo.GetbyId(id));
        }

        #endregion

        
        #region TypeGovtID
        [HttpGet]
        [Route("GetTypeOfGovtIDAsLookup")]
        public async Task<BaseResponse> GetTypeOfGovtIDAsLookup()
        {
            return constructResponse(_unitOfWork.Type_Govt_IDRepo.GetAll());
        }

        [HttpPost]
        [Route("TypeOfGovtIDPost")]
        public async Task<BaseResponse> TypeOfGovtIDPost([FromBody] Type_Of_Govt_IdDTO model)
        {
            await _unitOfWork.Type_Govt_IDRepo.Post(model);
            return constructResponse(await _unitOfWork.Save());
        }
        [HttpPut]
        [Route("TypeOfGovtIDUpdate")]
        public async Task<BaseResponse> TypeOfGovtIDUpdate([FromBody] Type_Of_Govt_IdDTO model)
        {
            _unitOfWork.Type_Govt_IDRepo.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("TypeOfGovtIDDelete/{id}")]
        public async Task<BaseResponse> TypeOfGovtID(int id)
        {
            _unitOfWork.Type_Govt_IDRepo.Delete(id);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpPost]
        [Route("TypeOfGovtIDbyIdPost/{id}")]
        public BaseResponse TypeOfGovtIDbyId(int id)
        {
            return constructResponse(_unitOfWork.Type_Govt_IDRepo.GetbyId(id));
        }

        #endregion
    }
}
