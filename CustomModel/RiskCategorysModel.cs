using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class RiskCategorysModel
    {
        public string Id { get; set; }
        //[Required]
        [Display(Name = "Risk Category Name")]
        public string Risk_Category_Name { get; set; }
        [Display(Name = "Tenant ID")]
        public long TenantID { get; set; }

        [Display(Name = "Tenant Type ID")]
        public int TenantTypeID { get; set; }
        
        //public DateTime Created_at { get; set; }
        public string CreatedBy { get; set; }
        
        //public DateTime? Modified_at { get; set; }
        public string ModifiedBy { get; set; }

        //public bool Isactive { get; set; }

        //public bool Isdeleted { get; set; }



    }
}
