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
    public class RiskCategorysController : ControllerBase
    {
        private readonly IRiskCategorysBAL _RiskCategorysBAL;
        public RiskCategorysController(IWebHostEnvironment host, IMapper mapper)
        {
            _RiskCategorysBAL = new RiskCategorysBAL(host, mapper);
        }
        [HttpPost, Route("GetAll")]      
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _RiskCategorysBAL.GetAllRiskCategorys(search);
            var pagedList = new PagedStaticList<RiskCategorysModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
            return Ok(await Task.FromResult(pagedList));
           
        }
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _RiskCategorysBAL.GetRiskCategorysById(id);
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
        [HttpPost, Route("SaveRiskCategorys")]        
        public async Task<IActionResult> Post([FromForm] RiskCategorysModel entities)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if (entities != null)
                {
                    i = await _RiskCategorysBAL.CreateRiskCategorys(entities);
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
        [HttpDelete, Route("DeleteRiskCategorys")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _RiskCategorysBAL.DeleteRiskCategorys(Id);
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
        [HttpPut, Route("UpdateRiskCategorys")]       
        public IActionResult Update([FromForm] RiskCategorysModel entites)
        {

            if (ModelState.IsValid)
            {
                var res = _RiskCategorysBAL.UpdateRiskCategorys(entites);
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
