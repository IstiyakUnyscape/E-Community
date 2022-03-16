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
    public class MilestoneController : ControllerBase
    {
        private readonly IMilestoneBAL _MilestoneBAL;
        public MilestoneController(IWebHostEnvironment host, IMapper mapper)
        {
            _MilestoneBAL = new MilestoneBAL(host, mapper);
        }
        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _MilestoneBAL.GetAllMilestone(search);
            var pagedList = new PagedStaticList<MilestoneModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
            return Ok(await Task.FromResult(pagedList));
        }
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _MilestoneBAL.GetMilestoneById(id);
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
        [HttpGet, Route("GetMilestoneByProjectId")]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = _MilestoneBAL.GetMilestoneByProjectId(id);
            return Ok(await Task.FromResult(result));
            
        }
        [HttpPost, Route("SaveMilestone")]
        public async Task<IActionResult> Post([FromForm] MilestoneModel entities)
        {

            int i = 0;
            var validate = _MilestoneBAL.ValidateStartEndDtae(entities.ProjectId, entities.Estimated_StartDate, entities.Estimated_EndDate);
            if (validate == true)
            {
                if (ModelState.IsValid)
                {
                    if (entities != null)
                    {
                        i = await _MilestoneBAL.CreateMilestone(entities);
                    }

                }
                else
                {
                    return BadRequest();
                }
                if (i > 0)
                {
                    return Ok(new { Code = 200, Message = "MileStone Save Successfully.", });
                }
                else
                {
                    return Ok(new { Code = 204, Message = "Something went wrong", });
                }
            }
            else
            {
                return Ok(new { Code = 204, Message = "MileStone StartDate And EndADate between Project StartDate And EndADate!", });
            }
        }

        [HttpDelete, Route("DeleteMilestone")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _MilestoneBAL.DeleteMilestone(Id);
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
        [HttpPut, Route("UpdateMilestone")]
        public IActionResult Update([FromForm] MilestoneModel entites)
        {
            var validate = _MilestoneBAL.ValidateStartEndDtae(entites.ProjectId, entites.Estimated_StartDate, entites.Estimated_EndDate);
            if (validate == true)
            {
              if (ModelState.IsValid)
              {
                var res = _MilestoneBAL.UpdateMilestone(entites);
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
            else
            {
                return Ok(new { Code = 204, Message = "MileStone StartDate And EndADate between Project StartDate And EndADate!", });
            }
        }
    }
}
