using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class UserActivationEntities
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public string VerificationCode { get; set; }
        public bool IsVarified { get; set; }
        public DateTime IsVarified_at { get; set; }
        public DateTime Created_at { get; set; }

    }
}
