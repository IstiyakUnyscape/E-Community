using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class GuestModel
    {
        public string id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string F_Name { get; set; }
        [Display(Name = "Middle Name")]
        public string M_Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string L_Name { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        public string Email_id { get; set; }
        [Display(Name = "Mobile No.")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Mobile_No { get; set; }
        [Required]
        [Display(Name = "Type of Visit")]
        public int Type_of_Visit { get; set; }
        [Required]
        [Display(Name = "Community")]
        public string Community { get; set; }
        [Required]
        [Display(Name = "Floor")]
        public string Floor { get; set; }
        [Required]
        [Display(Name = "Date of visit")]
        [DataType(DataType.Date) ,DisplayFormat(DataFormatString ="yyyy-MM-dd")]
        public DateTime Date_of_visit { get; set; }
        [Required]
        [Display(Name = "Time of visit")]
        [DataType(DataType.Time)]
        public TimeSpan Time_of_visit { get; set; }
        [Display(Name = "Purpose of the visit")]
        public string Purpose_of_the_visit { get; set; }
        [Display(Name = "Parking Required")]
        public bool Parking_required { get; set; }
        [Display(Name = "Car Model Details")]
        public string Car_model_details { get; set; }
        [Display(Name = "Plate No")]
        public string Plate_No { get; set; }
        [Display(Name = "Car Registration Card")]
        public string Car_Registration_Card { get; set; }
        [Display(Name = "ID No")]
        public string ID_No { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        public IFormFile Upload_ID_No_File { get; set; }
        [Display(Name = "Upload ID No")]
        public string Upload_ID_No { get; set; }
        [Display(Name = "Delivery Company Name")]
        public string Delivery_company_Name { get; set; }
        [Display(Name = "Delivery Staff Name")]
        public string Delivery_Staff_Name { get; set; }
        [Display(Name = "Staff ID Card No.")]
        public string Staff_ID_Card_No { get; set; }
        [Display(Name = "Staff ID Card Image")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        public IFormFile Staff_ID_Card_Image_File { get; set; }
        public string Staff_ID_Card_Image { get; set; }
        [Display(Name = "Type of Delivery")]
        public int Type_of_Delivery { get; set; }
        [Display(Name = "Company Name")]
        public string Company_Name { get; set; }
        [Display(Name = "Number of Staff to Reach the Unit")]
        public string Number_of_Staff_to_Reach_the_Unit { get; set; }
        [Display(Name = "Scope of Work")]
        public string Scope_of_Work { get; set; }
        [Display(Name = "Materials carrie in")]
        public string Materials_carrie_in { get; set; }
        [Display(Name = "Service Provider Staff Name")]
        public string Service_Provider_Staff_Name { get; set; }
        [Display(Name = "Staff Mobile Number")]
        public long Staff_Mobile_Number { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        public IFormFile Staff_ID_Card_image1_File { get; set; }
        [Display(Name = "Staff ID Card Image1")]
        public string Staff_ID_Card_image1 { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        public IFormFile Staff_ID_Card_image2_File { get; set; }
        [Display(Name = "Staff ID Card Image2")]
        public string Staff_ID_Card_image2 { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        public IFormFile Staff_ID_Card_image3_File { get; set; }
        [Display(Name = "Staff ID Card Image3")]
        public string Staff_ID_Card_image3 { get; set; }
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf", ".jpeg" })]
        public IFormFile Staff_ID_Card_image4_File { get; set; }
        [Display(Name = "Staff ID Card Image4")]
        public string Staff_ID_Card_image4 { get; set; }
        
    }
}
