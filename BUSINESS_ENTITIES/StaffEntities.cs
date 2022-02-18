using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class StaffEntities
    {
        public string Id { get; set; }
        public int Company_id { get; set; }
        public string F_Name { get; set; }
        public string M_Name { get; set; }
        public string L_Name { get; set; }
        public long Mobile_No { get; set; }
        public string Email_Id { get; set; }
        public int Designation { get; set; }
        public int Reporting_To { get; set; }
        public string Address { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Postal_Code { get; set; }
        public string Community { get; set; }
        public string Identification_CardNo { get; set; }
        public DateTime ID_expiry_Date { get; set; }
        public string ID_upload_Picture { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int Country_Code { get; set; }
        public int Std_Code { get; set; }
    }
}
