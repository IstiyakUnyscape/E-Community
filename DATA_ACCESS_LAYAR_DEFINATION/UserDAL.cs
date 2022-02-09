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
            dbparams.Add("Password", entity.Password);
            dbparams.Add("retVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = await Task.FromResult(_dapper.Execute<int>("sp_UserRegister", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public UserEntities Login(LoginEntitiies _obj)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Email", _obj.Email, DbType.String);
            //dbparams.Add("Password", _obj.Password, DbType.String);
            var res = _dapper.GetAll<UserEntities>("sp_GetUser", dbparams, commandType: CommandType.StoredProcedure).AsEnumerable();
            return res.Where(x=>x.Email_id==_obj.Email && x.Password==_obj.Password).FirstOrDefault();
        }
    }
}
