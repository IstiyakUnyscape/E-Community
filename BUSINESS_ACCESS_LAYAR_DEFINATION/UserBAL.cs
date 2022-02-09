using AutoMapper;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using COMMON_SERVICES_DEFINATION;
using COMMON_SERVICES_INTERFACE;
using CustomModel;
using DATA_ACCESS_LAYAR_DEFINATION;
using DATA_ACCESS_LAYAR_INTERFACE;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        public UserBAL(IMapper mapper)
        {
            _mapper = mapper;
            _UserDAL = new UserDAL();
            _Iencryption = new EncryptionDefination();
            _igetAppsetting = new GetAppsettingDefination();
        }

        public async Task<int> CreateUser(string obj)
        {
            UserEntities entities = new UserEntities();
            entities.Email_id = obj;
            var guid = Guid.NewGuid().ToString().Replace("-", "");
            var password = guid.Substring(0,8);
            entities.Password= _Iencryption.EncryptID(password);
            return await _UserDAL.Create(entities);
        }

        public async Task<UserModel> UserLogin(LoginEntitiies obj)
        {
            var data = new UserModel();
            try
            {
                var configuration = _igetAppsetting.getIconfiguration();
                var Key = configuration.GetSection("JWTKEY").Value;
                var _data = _UserDAL.Login(obj);
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
    }
}
