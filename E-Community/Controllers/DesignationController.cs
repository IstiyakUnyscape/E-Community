using AutoMapper;
using BUSINESS_ACCESS_LAYAR_DEFINATION;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using CustomModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Community.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationBAL _DesignationBAL;
        public DesignationController(IWebHostEnvironment host, IMapper mapper)
        {
            _DesignationBAL = new DesignationBAL(host, mapper);
        }
        [HttpPost, Route("GetAll")]      
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _DesignationBAL.GetAllDesignation(search);
            var pagedList = new PagedStaticList<DesignationModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
            return Ok(await Task.FromResult(pagedList));
           
        }
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _DesignationBAL.GetDesignationById(id);
                if (res != null)
                {
                    return Ok(await Task.FromResult(res));
                }
                else
                {
                    return Ok(new { Code = 204, data = res, Message = "No Data Found", });
                }

            }
            else
            {
                return Ok(new { Code = 201, Message = "token invalid ", });
            }
        }
        [HttpPost, Route("SaveDesignation")]        
        public async Task<IActionResult> Post([FromForm] DesignationModel entities)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if (entities != null)
                {
                    i = await _DesignationBAL.CreateDesignation(entities);
                }

            }
            else
            {
                return BadRequest();
            }
            if (i == 0)
            {
                return Ok(new { Code = 200, Message = "Registation Successfully", });
            }
            else
            {
                return Ok(new { Code = 204, Message = "Something went wrong", });
            }
        }
        [HttpDelete, Route("DeleteDesignation")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _DesignationBAL.DeleteDesignation(Id);
                if (res.Result == 0)
                {
                    return Ok(new { Code = 200, Message = "Data Deleted Successfully ", });
                }
                else
                {
                    return Ok(new { Code = 204, Message = "Data Not Found", });
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut, Route("UpdateDesignation")]       
        public IActionResult Update([FromForm] DesignationModel entites)
        {

            if (ModelState.IsValid)
            {
                var res = _DesignationBAL.UpdateDesignation(entites);
                if (res.Result == 0)
                {
                    return Ok(new { Code = 200, Message = "Data Update Successfully ", });
                }
                else
                {
                    return Ok(new { Code = 204, Message = "Data Not Found", });
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
