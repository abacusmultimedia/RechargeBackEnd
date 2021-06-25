using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace  Secure.Api.Controllers
{
    public class ProjectsController : BaseController
    {
        public ProjectsController(IUnitOfWork portalUnitOfWork ) : base(portalUnitOfWork)
        {

        }

        [HttpGet]
        [Route("Projects")]
        public BaseResponse GetProjects()
        {
            return   constructResponse(_unitOfWork.ProjectsRepository.GetAll());
        }
        [HttpGet]
        [Route("Project/{id}")]
        public BaseResponse GetProject(int id)
        {
            return constructResponse(_unitOfWork.ProjectsRepository.GetProjectById(id));
        }

        //[HttpPost]
        //[Route("IsProjectExist")]
        //public BaseResponse IsProjectExist([FromBody] ProjectExistsDTO ProjectExist)
        //{
        //    return null;
        //}

        [HttpGet]
        [Route("GetProjectTypes")]
        public BaseResponse GetProjectTypes()
        {
            return null;
        }
 

        [HttpGet]
        [Route("GetProjectGroups")]
        public BaseResponse GetProjectGroups()
        {
            return null;
        }

        [HttpPost]
        public async Task<BaseResponse> Post([FromBody] ProjectDTO model)
        {
            await _unitOfWork.ProjectsRepository.Post(model);
            return constructResponse(await _unitOfWork.Save());
            
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse> Put([FromBody] ProjectDTO model)
        {
              _unitOfWork.ProjectsRepository.Put(model);
            return constructResponse(await _unitOfWork.Save());
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
             _unitOfWork.ProjectsRepository.Delete(id);
            return constructResponse(await _unitOfWork.Save());
        }


    }
}
