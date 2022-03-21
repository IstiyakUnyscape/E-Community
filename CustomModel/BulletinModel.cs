using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class BulletinModel
    {
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public List<IFormFile> Upload_Pictures_File { get; set; }
        public string Upload_Pictures { get; set; }
        public List<IFormFile> Attach_Documents_Files { get; set; }
        public string Attach_Documents { get; set; }
        public long? Mobile_No { get; set; }
        public string EmailId { get; set; }
        //public decimal Price { get; set; }
        public string Availability_To_Contact { get; set; }
        //public DateTime Created_at { get; set; }
        public string CreatedBy { get; set; }
        //public DateTime? Modified_at { get; set; }
        public string ModifiedBy { get; set; }
        //public bool Isactive { get; set; }
        //public bool Isdeleted { get; set; }
        public bool IsShowAdmin { get; set; }
        public int? StatusTypeDetailID { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Remarks { get; set; }
    }
    public class Upload_Pictures_FileJson
    {
        public string Upload_Pictures { get; set; }
    }
    public class Attach_Documents_FileJson
    {
        public string Attach_Documents { get; set; }
    }
}
