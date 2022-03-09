using BUSINESS_ACCESS_LAYAR_DEFINATION;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
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
    public class CommonApiController : ControllerBase
    {
        private readonly ICommonApiBAL _CommonApiBAL;
        public CommonApiController()
        {
            //webHostEnvironment = host;
            _CommonApiBAL = new CommonApiBAL();
        }
        [HttpGet, Route("GetCountry")]
        public async Task<IActionResult> GetAll()
        {
            var result = _CommonApiBAL.GetCountry();
            
            if (result != null)
            {
                //return Ok(new { Code = 200, data = result, Message = "Data Access Succesffully ", });
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }
        }

        //GET api/<CompanyController>/5
        [HttpGet, Route("GetState")]
        public async Task<IActionResult> Get(int id)
        {
            if (id != 0)
            {
                var list = _CommonApiBAL.GetState(id);
                if (list != null)
                {
                    return Ok(await Task.FromResult(list));
                }
                else
                {
                    return Ok(new { Code = 204, data = list, Message = "No Data Found", });
                }

            }
            else
            {
                return Ok(new { Code = 201, Message = "token invalid ", });
            }
        }
        [HttpGet, Route("GetCity")]
        public async Task<IActionResult> GetCity(int id)
        {
            if (id != 0)
            {
                var list = _CommonApiBAL.GetCity(id);
                if (list != null)
                {
                    return Ok(await Task.FromResult(list));
                }
                else
                {
                    return Ok(new { Code = 204, data = list, Message = "No Data Found", });
                }

            }
            else
            {
                return Ok(new { Code = 201, Message = "token invalid ", });
            }
        }
        [HttpGet, Route("GetDesignation")]
        public async Task<IActionResult> GetDesignation()
        {
           
                var result = _CommonApiBAL.GetDesignation();
            if (result != null)
            {
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }
        }
        [HttpGet, Route("GetServices")]
        public async Task<IActionResult> GetService()
        {

            var result = _CommonApiBAL.GetService();
            if (result != null)
            {
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }
        }
        [HttpGet, Route("GetVisitType")]
        public async Task<IActionResult> GetVisitType()
        {

            var result = _CommonApiBAL.GetVisitType();
            if (result != null)
            {
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }

        }
        [HttpGet, Route("GetDeliveryType")]
        public async Task<IActionResult> GetDeliveryType()
        {

            var result = _CommonApiBAL.GetDeliveryType();
            if (result != null)
            {
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }
        }
        [HttpGet, Route("GetTypeMasterDetail")]
        public async Task<IActionResult> GetTypeMasterDetail()
        {

            var result = _CommonApiBAL.GetTypeMasterDetail();
            if (result != null)
            {
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }
        }
        [HttpGet, Route("GetCommunity")]
        public async Task<IActionResult> GetCommunity()
        {

            var result = _CommonApiBAL.GetCommunity();
            if (result != null)
            {
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }
        }
        [HttpGet, Route("GetDesignationBytenant")]
        public async Task<IActionResult> GetDesignation(int TenantTypeId, int TenantId)
        {

            var result = _CommonApiBAL.GetDesignationByTenantId(TenantTypeId, TenantId);
            if (result != null)
            {
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }
        }
        [HttpGet, Route("GetStaffByDesignationId")]
        public async Task<IActionResult> GetStaffByDesignationId( int DesignationId)
        {

            var result = _CommonApiBAL.GetStaffByDesignationId(DesignationId);
            if (result != null)
            {
                return Ok(await Task.FromResult(result));
            }
            else
            {
                return Ok(new { Code = 204, data = result, Message = "No Data Found", });
            }
        }
    }
}
