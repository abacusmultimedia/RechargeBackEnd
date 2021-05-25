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
    public class LookUpController : BaseController
    {
        public LookUpController(IUnitOfWork portalUnitOfWork ) : base(portalUnitOfWork)
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
        public  BaseResponse CategorybyId(int id)
        {
            return constructResponse( _unitOfWork.CategoryRepo.GetbyId(id));
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

    }
}
