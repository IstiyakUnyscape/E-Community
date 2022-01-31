using AutoMapper;
using BUSINESS_ACCESS_LAYAR_DEFINATION;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using CustomModel;
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
    public class VendorController : ControllerBase
    {
        private readonly IVendorsBAL _vendorBAL;

        //private IWebHostEnvironment webHostEnvironment;
        public VendorController(IWebHostEnvironment host, IMapper mapper)
        {
            //webHostEnvironment = host;
            _vendorBAL = new VendorsBAL(host, mapper);
        }
        // GET: api/<VendorController>
        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _vendorBAL.GetAllVendors(search);
            var pagedList = new PagedStaticList<VendorsModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
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

        //GET api/<VendorController>/5
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _vendorBAL.GetVendorsById(id);
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

        // POST api/<VendorController>
        [HttpPost, Route("SaveVendor")]
        public IActionResult Post([FromForm] VendorsModel entities)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if (entities != null)
                {
                    i = _vendorBAL.CreateVendors(entities).Result;
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

        [HttpDelete, Route("DeleteVendor")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _vendorBAL.DeleteVendors(Id);
                if (res.Result == 0)
                {
                    return Ok(new { Code = 200, data = res, Message = "Data Deleted Successfully ", });
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

        [HttpPut, Route("UpdateVendor")]
        public IActionResult Update([FromForm]VendorsModel entites)
        {

            if (ModelState.IsValid)
            {
                var res = _vendorBAL.UpdateVendors(entites);
                if (res.Result == 0)
                {
                    return Ok(new { Code = 200, data = res, Message = "Data Update Successfully ", });
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
