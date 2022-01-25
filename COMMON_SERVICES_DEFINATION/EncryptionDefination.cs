using COMMON_SERVICES_INTERFACE;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON_SERVICES_DEFINATION
{
    public class EncryptionDefination : Iencryption
    {
        private readonly IDataProtector protector;
        private readonly DataProtectionPurposeString dataProtectionPurposeString;
        private readonly IGetAppsetting _igetAppsetting;
        public EncryptionDefination()//(IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeString dataProtectionPurposeString)
        {
            //protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeString.Password);
            _igetAppsetting = new GetAppsettingDefination();
        }

        public string DecryptID(string value)
        {
            var configuration = _igetAppsetting.getIconfiguration();
            var Key = configuration.GetSection("EncryptKeyPassword").ToString();
            string DecryptID = " 0";
            try
            {
                DecryptID = new EncryptMethod().DecryptFromHex(value, Key);
            }
            catch (Exception ex)
            {
                //LogErrorToLogFile.WriteError(ex);
            }
            return DecryptID;
        }

        public string EncryptID(string value)
        {
            var configuration = _igetAppsetting.getIconfiguration();
            var Key = configuration.GetSection("EncryptKeyPassword").ToString();
            string EncryptedID = string.Empty;
            try
            {
                EncryptedID = new EncryptMethod().EncryptToHex(value.ToString(), Key);
            }
            catch
            {

            }
            return EncryptedID;
        }

        public string getDecryption(string _obj)
        {
            return protector.Unprotect(_obj);
        }

        public string getEncryption(string _obj)
        {
            return protector.Protect(_obj);
        }
    }
}
