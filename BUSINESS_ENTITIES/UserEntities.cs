using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class UserEntities
    {
        public string Id { get; set; }
        public string Email_id { get; set; }
        public string Password { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
    }
}
