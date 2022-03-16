using AutoMapper;
using BUSINESS_ACCESS_LAYAR_DEFINATION;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
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
    public class RiskRegistryController : ControllerBase
    {
        private readonly IRiskRegistryBAL _RiskRegistryBAL;
        public RiskRegistryController(IWebHostEnvironment host, IMapper mapper)
        {
            _RiskRegistryBAL = new RiskRegistryBAL(host, mapper);
        }
        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _RiskRegistryBAL.GetAllRiskRegistry(search);
            var pagedList = new PagedStaticList<RiskRegistryModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
            return Ok(await Task.FromResult(pagedList));
        }
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _RiskRegistryBAL.GetRiskRegistryById(id);
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
                return Ok(new { Code = 201, Message = "ID invalid ", });
            }
        }
        [HttpPost, Route("SaveRiskRegistry")]
        public async Task<IActionResult> Post([FromForm] RiskRegistryModel entities)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if (entities != null)
                {
                    i = await _RiskRegistryBAL.CreateRiskRegistry(entities);
                }

            }
            else
            {
                return BadRequest();
            }
            if (i > 0)
            {
                return Ok(new { Code = 200, Message = "Project Save and Sent Notification.", });
            }
            else
            {
                return Ok(new { Code = 204, Message = "Something went wrong", });
            }
        }

        [HttpDelete, Route("DeleteRiskRegistry")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _RiskRegistryBAL.DeleteRiskRegistry(Id);
                if (res.Result > 0)
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

        [HttpPut, Route("UpdateRiskRegistry")]
        public IActionResult Update([FromForm] RiskRegistryModel entites)
        {

            if (ModelState.IsValid)
            {
                var res = _RiskRegistryBAL.UpdateRiskRegistry(entites);
                if (res.Result > 0)
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
