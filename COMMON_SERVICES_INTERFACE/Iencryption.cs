using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON_SERVICES_INTERFACE
{
    public interface Iencryption
    {
        string getEncryption(string _obj);
        string getDecryption(string _obj);
        string EncryptID(string value);
        string DecryptID(string value);
    }
}
