using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class CompanyModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
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
        [Display(Name = "Owner First Name")]
        public string Owner_Fname { get; set; }
        [Required]
        [Display(Name = "Owner Last Name")]
        public string Owner_Lname { get; set; }

        [Display(Name = "Owner Mobile No.")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Owner_MobileNo { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        [Display(Name = "Owner Email_ID")]
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
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        [Display(Name = "Company Email_Id")]
        public string Company_Email_Id { get; set; }
        [Required]
        [Display(Name = "Trade License No.")]
        public string Trade_License_No { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Tradelicense Expiry Date")]
        public DateTime Tradelicense_Expiry_Date { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Trade license Copy")]
        public IFormFile Tradelicense_Copy_File { get; set; }
        public string Tradelicense_Copy { get; set; }
        [Required]
        [Display(Name = "Tax Return Number")]
        public long Tax_Return_Number { get; set; }
        // [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "TRN Certificate")]
        public IFormFile TRN_Certificate_File { get; set; }
        public string TRN_Certificate { get; set; }
        // [Required(ErrorMessage = "Please select a file.")]
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
        [Display(Name = "Number of Communities Managed")]
        public int Number_of_Communities_Managed { get; set; }
        [Required]
        [Display(Name = "Total Managed Common Area")]
        public int Total_Managed_Common_Area { get; set; }
        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "Additional Certificates")]
        //public IFormFile Additional_Certificates_File { get; set; }
        //public string Additional_Certificates { get; set; }
        //public List<IFormFile> Additional_CertificatesFiles { get; set; }
        public List<FileUploadModel> Additional_Certificates_FileUpload { get; set; }
        public string Additional_Certificates { get; set; }
        //public DateTime Created_at { get; set; }
        public string CreatedBy { get; set; }
        //public DateTime? Modified_at { get; set; }
        public string ModifiedBy { get; set; }
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
    public class FileUploadModel
    {
        [Display(Name = "Additional Certificate")]
        public IFormFile Additional_Certificate_File { get; set; }
        //public string Additional_Certificates { get; set; }
        public string Additional_Certificate_Title { get; set; }
        [Display(Name = "Additional Certificate Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime Additional_Certificate_ExpiryDate { get; set; }
    }
    public class AdditionalCertificateJson
    {
        public string Additional_Certificates { get; set; }
        public string Additional_Certificate_Title { get; set; }
        public DateTime Additional_Certificate_ExpiryDate { get; set; }
    }
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is { _maxFileSize} bytes.";
        }
    }
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"This File extension is not allowed!";
        }
    }
}
