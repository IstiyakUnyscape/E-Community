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
