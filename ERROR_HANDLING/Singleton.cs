
using CustomModel;
using Dapper;
using DapperServices;
using System;
using System.Data;

namespace ERROR_HANDLING
{
    public class Singleton
    {
        private static Singleton instance = null;
        private readonly Dapperr _dapper;
        public static Singleton getInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
        private Singleton()
        {
            _dapper = new Dapperr();
        }

        public void logExpection(ErrorEntitesModel entity)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("errorCode", entity.errorCode);
                dbparams.Add("errorType", entity.errorType);
                dbparams.Add("message", entity.message);
                dbparams.Add("innerMessage", entity.innerMessage);
                dbparams.Add("path", entity.path);
                var result = _dapper.Insert<int>("sp_InsertErrorLog", dbparams, commandType: CommandType.StoredProcedure);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


    }
}
