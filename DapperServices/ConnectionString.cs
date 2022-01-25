using COMMON_SERVICES_DEFINATION;
using COMMON_SERVICES_INTERFACE;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServices
{
    public class ConnectionString
    {
        protected SqlConnection _Connection { get; set; }
        private string connection { get; set; }
        private readonly IGetAppsetting _igetAppsetting;
        public ConnectionString()
        {
            _igetAppsetting = new GetAppsettingDefination();
        }
        public SqlConnection GetConnection()
        {

            var configuration = _igetAppsetting.getIconfiguration();
            this.connection = configuration.GetConnectionString("SqlConnection").ToString();
            _Connection = new SqlConnection(connection);
            return _Connection;

        }
    }
}
