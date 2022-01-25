using COMMON_SERVICES_INTERFACE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON_SERVICES_DEFINATION
{
    public class EncryptionPasswordDefination : Iencryption
    {
        private readonly IGetAppsetting _igetAppsetting;
        public EncryptionPasswordDefination()
        {
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
            throw new NotImplementedException();
        }

        public string getEncryption(string _obj)
        {
            throw new NotImplementedException();
        }
    }
}
