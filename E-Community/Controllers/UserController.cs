using AutoMapper;
using BUSINESS_ACCESS_LAYAR_DEFINATION;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
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
        public UserController(IMapper mapper, EmailCofiguration emailCofiguration)
        {
            _UserBAL = new UserBAL(mapper, emailCofiguration);
        }
        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _UserBAL.GetAllUser();
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

            string i = null;
           
            if (EmailId != null)
            {
                i = _UserBAL.CreateUser(EmailId).Result;
            }
            if (i != "-1")
            {
                var res = _UserBAL.VerificatoinLink(i);
                if(res.Result==true)
                {
                    return Ok(new { Code = 200, Result=res.Result, Message = "Verification link is Sent on the email", });
                }
                else
                {
                    return Ok(new { Code = 200, Message = "Registation Successfully But Not Sent Verification Link", });
                }
                
            }
            else
            {
                return Ok(new { Code = 204, Message = "Email Id Already Exist or Something went wrong", });
            }
        }
        [HttpPost, Route("SendVarificatoinLink")]
        public IActionResult Send(string userid)
        {
            var res = _UserBAL.VerificatoinLink(userid);
            if(res.Result ==true)
            {
                return Ok(new { Code = 200, Message = "Verification link is Sent on the email", });
            }
            else
            {
                return Ok(new { Code = 204, Message = "Verification Link Not Sent!", });
            }
            
        }
        [HttpGet, Route("VerifyUserEmail")]
        public IActionResult UserVarified(string userid,string code)
        {
            var res = _UserBAL.UserVerified(userid, code);
            if(res.Result== 1)
            {

                return Ok(new { Code = 200, StatusCode=1, Message = "Success", });
            }
            else
            {
                if (res.Result == 2)
                {
                    return BadRequest(new { Code = 400, StatusCode = 2, Message = "Link is Expired", });
                }
                else
                {
                    return BadRequest(new { Code = 400, StatusCode = 3, Message = "Email Already Verified with this Link. Password is already Created by User."});
                }
                
            }
            
        }
        [HttpPost, Route("CreatePassword")]
        public IActionResult CreatePassword(string userid,string Password)
        {
            var res = _UserBAL.CreatePassword(userid, Password);
            if (res.Result == 1)
            {
                return Ok(new { Code = 200, Message = "Password is Created", });
            }
            else
            {
                return BadRequest(new { Code = 400, Message = "Password Is Not Created", });
            }

        }
        [HttpPost, Route("LoginByUserId")]
        public async Task<IActionResult> UserLogin(string UserId, string Password)
        {
            var res = _UserBAL.LoginByUserId(UserId, Password);
            if (res.Result != null)
            {
                return Ok(await Task.FromResult(res));
            }
            else
            {
                return Ok(new { Code = 204, data = res, Message = "No Data Found", });
            }
        }
    }
}
