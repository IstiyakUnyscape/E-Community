using AutoMapper;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using COMMON_SERVICES_DEFINATION;
using COMMON_SERVICES_INTERFACE;
using CustomModel;
using DATA_ACCESS_LAYAR_DEFINATION;
using DATA_ACCESS_LAYAR_INTERFACE;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ACCESS_LAYAR_DEFINATION
{
    public class UserBAL : IUserBAL
    {
        private readonly IUserDAL _UserDAL;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        private readonly IGetAppsetting _igetAppsetting;
        private readonly Iemail _mailService;
        public UserBAL(IMapper mapper, EmailCofiguration emailCofiguration)
        {
            _mapper = mapper;
            _UserDAL = new UserDAL();
            _Iencryption = new EncryptionDefination();
            _igetAppsetting = new GetAppsettingDefination();
            _mailService = new IemailDefination(emailCofiguration);
        }

        public async Task<string> CreateUser(string obj)
        {
            UserEntities entities = new UserEntities();
            entities.Email_id = obj;
            //var guid = Guid.NewGuid().ToString().Replace("-", "");
            //var password = guid.Substring(0,8);
            //entities.Password= _Iencryption.EncryptID(password);
            var res= await _UserDAL.Create(entities);
            if(res==-1)
            {
                return res.ToString();
            }
            else
            {
                return _Iencryption.EncryptID(res.ToString());
            }
            
        }

        public async Task<bool> VerificatoinLink(string UserId)
        {
            bool send= false;
            var id= _Iencryption.DecryptID(UserId);
            var _data = _UserDAL.GetAll().Where(x => x.Id == id).FirstOrDefault();
            string VerificationCode = Guid.NewGuid().ToString();
            var res = await _UserDAL.UserActivation(id, VerificationCode);
            var configuration = _igetAppsetting.getIconfiguration();
            var Url = configuration.GetSection("BaseUrl").Value;
            var varifylink= "<br /><a href ='" +Url+ "User/EmailVerification?UserId=" + UserId + "&VerificationCode=" + VerificationCode + "'>Click here to activate your account.</a>";
            MailRequestEntites _obj = new MailRequestEntites(new string[] { _data.Email_id }, varifylink, new List<IFormFile> { });
            if(res==1)
            {
               send = await _mailService.SendasynchronouslyEmail(_obj);
            }
            return send;
             
        }

        public async Task<UserModel> UserLogin(LoginEntitiies obj)
        {
            var data = new UserModel();
            try
            {
                var configuration = _igetAppsetting.getIconfiguration();
                var Key = configuration.GetSection("JWTKEY").Value;
                string pwd=  _Iencryption.EncryptID(obj.Password); ;
                var _data = _UserDAL.GetAll().Where(x => x.Email_id == obj.Email && x.Password ==pwd).FirstOrDefault();
                data = _mapper.Map<UserModel>(_data);
                if (data != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(Key);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                          new Claim(ClaimTypes.Name,data.Id.ToString()),
                          new Claim(ClaimTypes.Role, data.Role)
                        }),
                        Expires = DateTime.Now.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    data.token = tokenHandler.WriteToken(token);
                    data.Id= _Iencryption.EncryptID(data.Id);
                    return data;
                }
            }
            catch(Exception ex)
            {

            }
            return data;
        }

        public async Task<int> UserVerified(string UserId, string Code)
        {
            int status=0;
            var id = _Iencryption.DecryptID(UserId);
            var res =await _UserDAL.ValidateVerificationCode(id,Code);
            var currentdate = DateTime.Now;
            var expiredate = res.Created_at.AddDays(7); //Convert.ToInt32(currentdate.Subtract(res.Created_at));
           
            if (res.IsVerified == true)
            {
                status = 1;
                var _data = _UserDAL.GetAll().Where(x => x.Id == id).FirstOrDefault();
                if (_data.IsPasswordCreated == true)
                {
                    status = 3;
                }
            }
            else
            {
                if (expiredate < currentdate)
                {
                    status = 2;
                }
                else
                {
                    var Isvarified = await _UserDAL.UserVerification(id, Code);
                    if(Isvarified==1)
                    {
                        status = 1;
                    }
                }
            }
            
            return status;
        }

        public async Task<int> CreatePassword(string UserId, string Password)
        {
            var id = _Iencryption.DecryptID(UserId);
            var password = _Iencryption.EncryptID(Password);
            var res = await _UserDAL.CreatePassword(id, password);
            return res;
        }
        public async Task<UserModel> LoginByUserId(string UserId, string Password)
        {
            var data = new UserModel();
            try
            {
                var id= _Iencryption.DecryptID(UserId);
                var password = _Iencryption.EncryptID(Password);
                var configuration = _igetAppsetting.getIconfiguration();
                var Key = configuration.GetSection("JWTKEY").Value;
                var _data = _UserDAL.GetAll().Where(x => x.Id == id && x.Password == password).FirstOrDefault();
                data = _mapper.Map<UserModel>(_data);
                if (data != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(Key);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                          new Claim(ClaimTypes.Name,data.Id.ToString()),
                          new Claim(ClaimTypes.Role, data.Role)
                        }),
                        Expires = DateTime.Now.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    data.token = tokenHandler.WriteToken(token);
                    data.Id = _Iencryption.EncryptID(data.Id);
                    return data;
                }
            }
            catch (Exception ex)
            {

            }
            return data;
        }
    }
}
