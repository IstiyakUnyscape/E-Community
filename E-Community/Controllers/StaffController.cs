using AutoMapper;
using BUSINESS_ACCESS_LAYAR_DEFINATION;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using CustomModel;
using E_Community.CustomFilter;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Community.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [CustomExceptionHandler]
    [Consumes("multipart/form-data")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffBAL _StaffBAL;
        //private IWebHostEnvironment webHostEnvironment;
        public StaffController(IWebHostEnvironment host, IMapper mapper)
        {
            //webHostEnvironment = host;
            _StaffBAL = new StaffBAL(host, mapper);
        }
        // GET: api/<StaffController>
        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _StaffBAL.GetAllStaff(search);
            var pagedList = new PagedStaticList<StaffModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
            return Ok(await Task.FromResult(pagedList));
            //if (list.Result != null)
            //{
            //    return Ok(new { Code = 200, data = list, Message = "Data Access Succesffully ", });
            //}
            //else
            //{
            //    return Ok(new { Code = 204, data = list, Message = "No Data Found", });
            //}
        }

        //GET api/<StaffController>/5
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _StaffBAL.GetStaffById(id);
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

        // POST api/<StaffController>
        [HttpPost, Route("SaveStaff")]
        public IActionResult Post([FromForm] StaffModel entities)
        {

            string i = string.Empty;
            if (ModelState.IsValid)
            {
                if (entities != null)
                {
                    i = _StaffBAL.CreateStaff(entities).Result;
                }

            }
            else
            {
                return BadRequest();
            }
            if (i != "-1")
            {
                return Ok(new { Code = 200, StaffUserId = i, Message = "Registation Successfully", });
            }
            else
            {
                return Ok(new { Code = 204, Message = "Something went wrong", });
            }
        }

        [HttpDelete, Route("DeleteStaff")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _StaffBAL.DeleteStaff(Id);
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

        [HttpPut, Route("UpdateStaff")]
        public IActionResult Update([FromForm] StaffModel entites)
        {

            if (ModelState.IsValid)
            {
                var res = _StaffBAL.UpdateStaff(entites);
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
