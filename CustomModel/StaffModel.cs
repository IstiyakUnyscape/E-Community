using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class StaffModel
    {
        public string Id { get; set; }
        [Required]
        public int Tenant_Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string F_Name { get; set; }
        [Display(Name = "Middle Name")]
        public string M_Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string L_Name { get; set; }
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile Number")]
        public long Mobile_No { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        [Display(Name = "Email ID")]
        public string Email_Id { get; set; }
        [Required]
        public int Designation { get; set; }
        [Required]
        [Display(Name = "Reporting To")]
        public int Reporting_To { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Country { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public int City { get; set; }
        [Display(Name = "Postal Code")]
        [Required]
        public string Postal_Code { get; set; }
        [Required]
        public string Community { get; set; }
        [Required]
        [Display(Name = "Identification Card No")]
        public string Identification_CardNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "ID Expiry Date")]
        public DateTime ID_expiry_Date { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "ID Upload Picture File")]
        public IFormFile ID_upload_Picture_File { get; set; }
        public string ID_upload_Picture { get; set; }
        //public DateTime Created_at { get; set; }
        public string CreatedBy { get; set; }
        // public DateTime? Modified_at { get; set; }
        public string ModifiedBy { get; set; }
        //public bool Isactive { get; set; }
        //public bool Isdeleted { get; set; }
        public int? Country_Code { get; set; }
        public int? Std_Code { get; set; }
        public int TenantTypeId { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(1 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        [Display(Name = "Profile Image")]
        public IFormFile Profile_Image_File { get; set; }
        public string Profile_Image { get; set; }
    }
    public class StaffViewModel : StaffModel
    {
        public string LoginUserId { get; set; }
        public string Company_Name { get; set; }
        public string DesignationName { get; set; }
        public string Reporting_To_Name { get; set; }
        public string Country_Name { get; set; }
        public string State_Name { get; set; }
        public string City_Name { get; set; }

    }
}
