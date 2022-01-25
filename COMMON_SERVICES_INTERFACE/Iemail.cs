using BUSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON_SERVICES_INTERFACE
{
    public interface Iemail
    {
        Task<Boolean> SendasynchronouslyEmail(MailRequestEntites _obj);
    }
}
