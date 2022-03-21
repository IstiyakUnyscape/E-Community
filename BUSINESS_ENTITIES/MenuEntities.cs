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

        

    }
}
