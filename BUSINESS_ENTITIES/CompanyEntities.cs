using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class CompanyEntities
    {
        public string Id { get; set; }
        public string Company_Name { get; set; }
        public string Company_Address { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Postal_Code { get; set; }
        public string Owner_Fname { get; set; }
        public string Owner_Lname { get; set; }
        public long Owner_MobileNo { get; set; }
        public string Owner_Email_ID { get; set; }
        public int Owner_Nationality { get; set; }
        public long Company_LandlineNo { get; set; }
        public string Company_Website { get; set; }
        public string Company_Email_Id { get; set; }
        public string Trade_License_No { get; set; }
        public DateTime Tradelicense_Expiry_Date { get; set; }
        public string Tradelicense_Copy { get; set; }
        public long Tax_Return_Number { get; set; }
        public string TRN_Certificate { get; set; }
        public string Owner_Passport_Copy { get; set; }
        public string Owner_Visa_Copy { get; set; }
        public int Number_of_Communities_Managed { get; set; }
        public int Total_Managed_Common_Area { get; set; }
        public string Additional_Certificates { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int Country_Code { get; set; }
        public int Std_Code { get; set; }
        public bool IsShowAdmin { get; set; }
        public int StatusTypeDetailID { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Remarks { get; set; }
        public string TenantTypeId { get; set; }
    }
}
