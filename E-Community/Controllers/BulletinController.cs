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
    public class BulletinController : ControllerBase
    {
        private readonly IBulletinBAL _BulletinBAL;
        public BulletinController(IWebHostEnvironment host, IMapper mapper)
        {
            _BulletinBAL = new BulletinBAL(host, mapper);
        }
        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _BulletinBAL.GetAllBulletin(search);
            var pagedList = new PagedStaticList<BulletinViewModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
            return Ok(await Task.FromResult(pagedList));
        }
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _BulletinBAL.GetBulletinById(id);
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
        [HttpPost, Route("SaveBulletin")]
        public async Task<IActionResult> Post([FromForm] BulletinModel entities)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if (entities != null)
                {
                    i = await _BulletinBAL.CreateBulletin(entities);
                }

            }
            else
            {
                return BadRequest();
            }
            if (i > 0)
            {
                return Ok(new { Code = 200, Message = "Bulletin Save and Sent Notification.", });
            }
            else
            {
                return Ok(new { Code = 204, Message = "Something went wrong", });
            }
        }

        [HttpDelete, Route("DeleteBulletin")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _BulletinBAL.DeleteBulletin(Id);
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

        [HttpPut, Route("UpdateBulletin")]
        public IActionResult Update([FromForm] BulletinModel entites)
        {

            if (ModelState.IsValid)
            {
                var res = _BulletinBAL.UpdateBulletin(entites);
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
