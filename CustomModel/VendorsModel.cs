using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class VendorsModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string Company_Name { get; set; }
        [Required]
        [Display(Name = "Company Address")]
        public string Company_Address { get; set; }
        [Required]
        public int Country { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public int City { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string Postal_Code { get; set; }
        [Required]
        [Display(Name = "Owner Fname")]
        public string Owner_Fname { get; set; }
        [Required]
        [Display(Name = "Owner Lname")]
        public string Owner_Lname { get; set; }
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Owner MobileNo")]
        public long Owner_MobileNo { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [Display(Name = "Owner Email ID")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        public string Owner_Email_ID { get; set; }
        [Required]
        [Display(Name = "Owner Nationality")]
        public int Owner_Nationality { get; set; }
        [Required]
        [Display(Name = "Company LandlineNo")]
        public long Company_LandlineNo { get; set; }
        [Required]
        [Display(Name = "Company Website")]
        public string Company_Website { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [Display(Name = "Company Email Id")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        public string Company_Email_Id { get; set; }
        [Required]
        [Display(Name = "Trade License No")]
        public string Trade_License_No { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Trade License No")]
        public DateTime Tradelicense_Expiry_Date { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Tradelicense Copy")]
        public IFormFile Tradelicense_Copy_File { get; set; }
        public string Tradelicense_Copy { get; set; }
        [Required]
        [Display(Name = "Tax Return Number")]
        public long Tax_Return_Number { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "TRN Certificate")]
        public IFormFile TRN_Certificate_File { get; set; }
        public string TRN_Certificate { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Owner Passport Copy")]
        public IFormFile Owner_Passport_Copy_File { get; set; }
        public string Owner_Passport_Copy { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Owner Visa Copy")]
        public IFormFile Owner_Visa_Copy_File { get; set; }
        public string Owner_Visa_Copy { get; set; }
        [Required]
        [Display(Name = "Bank Name")]
        public string Bank_Name { get; set; }
        [Required]
        [Display(Name = "Bank Address")]
        public string Bank_Address { get; set; }
        [Required]
        [Display(Name = "Account Name")]
        public string Account_Name { get; set; }
        [Required]
        [Display(Name = "Account Number")]
        public string Account_Number { get; set; }
        [Required]
        [Display(Name = "IBAN Number")]
        public string IBAN_Number { get; set; }
        [Required]
        [Display(Name = "SWIFT Code")]
        public string SWIFT_Code { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Third Party Liability Insurance Copy")]
        public IFormFile Third_Party_Liability_Insurance_Copy_File { get; set; }
        public string Third_Party_Liability_Insurance_Copy { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Third Party Liability Insurance Copy Expiry Date")]
        public DateTime Third_Party_Liability_Insurance_Copy_ExpiryDate { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Workmen Compensation Insurance Copy")]
        public IFormFile Workmen_Compensation_Insurance_Copy_File { get; set; }
        public string Workmen_Compensation_Insurance_Copy { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Workmen Compensation Insurance Expiry Date")]
        public DateTime Workmen_Compensation_Insurance_ExpiryDate { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Additional Insurance")]
        public IFormFile Additional_Insurance_File { get; set; }
        public string Additional_Insurance { get; set; }
        [Display(Name = "Additional Insurance ExpiryDate")]
        [DataType(DataType.Date)]
        public DateTime Additional_Insurance_ExpiryDate { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Additional Certificate")]
        public IFormFile Additional_Certificate_File { get; set; }
        public string Additional_Certificate { get; set; }
        [Display(Name = "Additional Certificate Title")]
        public string Additional_Certificate_Title { get; set; }
        [Display(Name = "Additional Certificate Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime Additional_Certificate_ExpiryDate { get; set; }
        [Required(ErrorMessage = "Please select a Service Type.")]
        [Display(Name = "Service Type")]
        public int Service_Type { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        //public DateTime Created_at { get; set; }
        //public DateTime? Modified_at { get; set; }

        //public bool Isactive { get; set; }
        //public bool Isdeleted { get; set; }
        public int Country_Code { get; set; }
        public int Std_Code { get; set; }
        public bool IsShowAdmin { get; set; }
        public int StatusTypeDetailID { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Remarks { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(1 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        [Display(Name = "Profile Image")]
        public IFormFile Profile_Image_File { get; set; }
        public string Profile_Image { get; set; }
    }
}
