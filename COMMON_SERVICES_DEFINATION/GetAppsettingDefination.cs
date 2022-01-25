using COMMON_SERVICES_INTERFACE;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON_SERVICES_DEFINATION
{
    public class GetAppsettingDefination : IGetAppsetting
    {
        public IConfigurationRoot getIconfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            return configuration; throw new NotImplementedException();
        }
    }
}
