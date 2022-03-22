using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class MenuEntities
    {
        public string id { get; set; }
        public string Menu_Display_Name { get; set; }        
        public string Logical_Name { get; set; }
        public int ParentID { get; set; }
        public string Controller_Name { get; set; }
        public string ActionName { get; set; }
        public string Http_Method { get; set; }
        public string Optional_RouteValues { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }



    }
}
