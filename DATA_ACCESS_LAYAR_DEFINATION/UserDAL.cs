using BUSINESS_ENTITIES;
using CustomModel;
using Dapper;
using DapperServices;
using DATA_ACCESS_LAYAR_INTERFACE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_ACCESS_LAYAR_DEFINATION
{
    public class UserDAL: IUserDAL
    {
        private readonly Dapperr _dapper;
        public UserDAL()
        {
            _dapper = new Dapperr();
        }

        public async Task<int> Create(UserEntities entity)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("Email_id", entity.Email_id);
            //dbparams.Add("Password", entity.Password);
            dbparams.Add("retVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = await Task.FromResult(_dapper.Execute<int>("sp_UserRegister", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> CreatePassword(string UserId, string Password)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("UserId", UserId, DbType.Int32);
            dbparams.Add("Password", Password, DbType.String);
            var res = await Task.FromResult(_dapper.Update<int>("sp_CreatePassword", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IEnumerable<UserEntities> GetAll()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<UserEntities>("sp_GetUser", dbparams, commandType: CommandType.StoredProcedure).AsEnumerable();
            return res;
        }

        public async Task<int> UserActivation(string UserId, string Code)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("UserId", UserId, DbType.Int32);
            dbparams.Add("VerificationCode", Code, DbType.String);
            var res = await Task.FromResult(_dapper.Insert<int>("sp_UserActivation", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> UserVerification(string UserId, string Code)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("UserId", UserId, DbType.Int32);
            dbparams.Add("VerificationCode", Code, DbType.String);
            var res = await Task.FromResult(_dapper.Update<int>("sp_UserVerification", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<UserActivationEntities> ValidateVerificationCode(string UserId, string Code)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("UserId", UserId, DbType.Int32);
            dbparams.Add("VarificationCode", Code, DbType.String);
            var res = await Task.FromResult(_dapper.Get<UserActivationEntities>("sp_ValidateVerificationCode", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }
    }
}
