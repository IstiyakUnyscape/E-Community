using AutoMapper;
using BUSINESS_ACCESS_LAYAR_DEFINATION;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using CustomModel;
using E_Community.CustomFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Community.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [CustomExceptionHandler]
    [Consumes("multipart/form-data")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompaniesBAL _companiesBAL;
        //private IWebHostEnvironment webHostEnvironment;
        public CompanyController(IWebHostEnvironment host, IMapper mapper)
        {
                //webHostEnvironment = host;
               _companiesBAL = new CompaniesBAL(host, mapper);
        }
        // GET: api/<CompanyController>
        [Authorize(Roles= "Zylin Admin")]
        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _companiesBAL.GetAllCompany();
            //var pagedList = new PagedStaticList<CompanyModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
            return Ok(await Task.FromResult(result));
            //if (list.Result != null)
            //{
            //    return Ok(new { Code = 200, data = list, Message = "Data Access Succesffully ", });
            //}
            //else
            //{
            //    return Ok(new { Code = 204, data = list, Message = "No Data Found", });
            //}
        }
        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromForm] SearchCompanyModel search)
        {
            var result = _companiesBAL.GetAllCompany(search);
            var pagedList = new PagedStaticList<CompanyModel> { Items = result, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalItemCount = result.TotalItemCount };
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

        //GET api/<CompanyController>/5
        [HttpGet, Route("GetByID")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var res = _companiesBAL.GetCompanyById(id);
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

        // POST api/<CompanyController>
        [HttpPost, Route("SaveCompany")]
        public async Task<IActionResult> Post([FromForm] CompanyModel entities)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if(entities!=null)
                {
                    i =await _companiesBAL.CreateCompany(entities);
                }
                 
            }
            else
            {
                return BadRequest();
            }
            if (i >0)
            {
                return Ok(new { Code = 200, Message = "Registation Successfully", });
            }
            else
            {
                return Ok(new { Code = 204, Message = "Something went wrong", });
            }
        }

        [HttpDelete, Route("DeleteCompany")]
        public IActionResult Delete(string Id)
        {
            if (Id != null)
            {
                var res = _companiesBAL.DeleteCompany(Id);
                if (res.Result == 0)
                {
                    return Ok(new { Code = 200, Message = "Data Deleted Successfully ", });
                }
                else
                {
                    return Ok(new { Code = 204, Message = "Data Not Found", });
                }
            }else
            {
                return BadRequest();
            }
        }

        [HttpPut, Route("UpdateCompany")]
        public IActionResult Update([FromForm]CompanyModel entites)
        {

            if (ModelState.IsValid)
            {
                var res = _companiesBAL.UpdateCompany(entites);
                if (res.Result>0)
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
        [HttpPost, Route("PostTest")]
        public async Task<IActionResult> PostTest([FromForm] List<FileUploadModel> entities)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if (entities != null)
                {
                    //i = await _companiesBAL.CreateCompany(entities);
                }

            }
            else
            {
                return BadRequest();
            }
            if (i > 0)
            {
                return Ok(new { Code = 200, Message = "Registation Successfully", });
            }
            else
            {
                return Ok(new { Code = 204, Message = "Something went wrong", });
            }
        }
    }
}
