using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class DeveloperModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string F_Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string L_Name { get; set; }
        [Required]
        [Display(Name = "Mobile No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Mobile_No { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        public string Email_Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Country { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public int City { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string Postal_Code { get; set; }
        [Display(Name = "Contact Person")]
        public string Contact_Person { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        [Display(Name = "License Document File")]
        public IFormFile License_Document_File { get; set; }
        public string License_Document { get; set; }
    }
}
