using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class VendorsEntities
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
        public string Bank_Name { get; set; }
        public string Bank_Address { get; set; }
        public string Account_Name { get; set; }
        public string Account_Number { get; set; }
        public string IBAN_Number { get; set; }
        public string SWIFT_Code { get; set; }
        public string Third_Party_Liability_Insurance_Copy { get; set; }
        public DateTime Third_Party_Liability_Insurance_Copy_ExpiryDate { get; set; }
        public string Workmen_Compensation_Insurance_Copy { get; set; }
        public DateTime Workmen_Compensation_Insurance_ExpiryDate { get; set; }
        public string Additional_Insurance { get; set; }
        public DateTime? Additional_Insurance_ExpiryDate { get; set; }
        public string Additional_Certificate { get; set; }
        //public string Additional_Certificate_Title { get; set; }
        //public DateTime Additional_Certificate_ExpiryDate { get; set; }
        public string Service_Type { get; set; }
        public DateTime Created_at { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int? Country_Code { get; set; }
        public int? Std_Code { get; set; }
        public bool IsShowAdmin { get; set; }
        public int? StatusTypeDetailID { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Remarks { get; set; }
        public string Profile_Image { get; set; }

    }
}
