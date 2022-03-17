using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class DesignationModel
    {
        public string Id { get; set; }
        //[Required]
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        //[Required]
        [Display(Name = "Designation Description")]
        public string DesignationDescription { get; set; }

        [Display(Name = "Tenant Type ID")]
        public int? TenantTypeID { get; set; }

        [Display(Name = "Tenant ID")]
        public long? TenantID { get; set; }
        //public DateTime Created_at { get; set; }
        public int? CreatedBy { get; set; }
        //public bool Isactive { get; set; }
        //public bool Isdeleted { get; set; }
        //public DateTime? Modified_at { get; set; }
        public int? ModifiedBy { get; set; }



    }
}
