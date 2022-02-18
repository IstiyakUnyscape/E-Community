using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IUserBAL
    {
        Task<UserModel> UserLogin(LoginEntitiies obj);
        public Task<string> CreateUser(string obj);
        public Task<bool> VerificatoinLink(string UserId);
        public Task<int> UserVerified(string UserId, string Code);
        public Task<int> CreatePassword(string UserId, string Password); 
        public Task<UserModel> LoginByUserId(string UserId, string Password);
    }
}
