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
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperBAL _DeveloperBAL;
        public DeveloperController(IWebHostEnvironment host, IMapper mapper)
        {
            _DeveloperBAL = new DeveloperBAL(host, mapper);
        }
        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _DeveloperBAL.GetAllDeveloper(search);
            var pagedList = new PagedStaticList<DeveloperModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
            return Ok(await Task.FromResult(pagedList));
           
        }
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _DeveloperBAL.GetDeveloperById(id);
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
        [HttpPost, Route("SaveDeveloper")]
        public async Task<IActionResult> Post([FromForm] DeveloperModel entities)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if (entities != null)
                {
                    i = await _DeveloperBAL.CreateDeveloper(entities);
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
        [HttpDelete, Route("DeleteDeveloper")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _DeveloperBAL.DeleteDeveloper(Id);
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
        [HttpPut, Route("UpdateDeveloper")]
        public IActionResult Update([FromForm] DeveloperModel entites)
        {

            if (ModelState.IsValid)
            {
                var res = _DeveloperBAL.UpdateDeveloper(entites);
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
