using AutoMapper;
using BUSINESS_ACCESS_LAYAR_DEFINATION;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using CustomModel;
using E_Community.CustomFilter;
using Microsoft.AspNetCore.Cors;
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
    //[Consumes("multipart/form-data")]
    public class UserController : ControllerBase
    {
        private readonly IUserBAL _UserBAL;
        public UserController(IMapper mapper)
        {
            _UserBAL = new UserBAL(mapper);
        }
        [HttpPost, Route("UserLogin")]
        public async Task<IActionResult> Login(LoginEntitiies obj)
        {
            var res = _UserBAL.UserLogin(obj);
            if(res.Result!=null)
            {
                return Ok(await Task.FromResult(res));
            }
            else
            {
               return Ok(new { Code = 204, data = res, Message = "No Data Found", });
            }
        }
        [HttpPost, Route("RegisterUser")]
        public IActionResult Post(string EmailId)
        {

            int i = 0;
            if (ModelState.IsValid)
            {
                if (EmailId != null)
                {
                    i = _UserBAL.CreateUser(EmailId).Result;
                }

            }
            else
            {
                return BadRequest();
            }
            if (i > 0)
            {
                return Ok(new { UserId = i, Code = 200, Message = "Registation Successfully", }) ;
            }
            else
            {
                return Ok(new { Code = 204, Message = "Something went wrong", });
            }
        }
    }
}
