using BUSINESS_ENTITIES;
using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_ACCESS_LAYAR_INTERFACE
{
    public interface IUserDAL
    {
       IEnumerable<UserEntities> GetAll();
       Task<int> Create(UserEntities entity);
       public Task<UserActivationEntities> ValidateVerificationCode (string UserId, string Code);
       public Task<int> UserActivation(string UserId, string Code);
        public Task<int> UserVerification(string UserId, string Code);
        public Task<int> CreatePassword(string UserId, string Password);
    }
}
