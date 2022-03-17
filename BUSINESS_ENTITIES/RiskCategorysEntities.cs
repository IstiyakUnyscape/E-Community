using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class RiskCategorysEntities
    {
        public string id { get; set; }
        public string Risk_Category_Name { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public long? TenantID { get; set; }
        public int? TenantTypeID { get; set; }
        public DateTime? Modified_at { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        

    }
}
