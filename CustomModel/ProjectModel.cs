using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class ProjectModel
    {
        public string Id { get; set; }
        [Required]
        public int Community { get; set; }
        public int Designation { get; set; }
        public int? Name { get; set; }
        [Required]
        public string Project_Description { get; set; }
        [Required]
        public DateTime Estimated_StartDate { get; set; }
        [Required]  
        public DateTime Estimated_EndDate { get; set; }
        public int Duration { get; set; }
        [Required]
        public Decimal Estimated_TotaleCost { get; set; }
        public List<IFormFile> Upload_Document_File { get; set; }
        public string Upload_Document { get; set; }
        [Required]
        public bool Show_EstimatedCost { get; set; }
        [Required]
        public int StatusTypeDetailId { get; set; }
        public string ReasonOnHold { get; set; }
        //public DateTime Created_at { get; set; }
        public string CreatedBy { get; set; }
        //public DateTime? Modified_at { get; set; }
        public string ModifiedBy { get; set; }
        // public bool Isactive { get; set; }
        // public bool Isdeleted { get; set; }
    }
        public class Documents_FileJson
        {
         public string Upload_Document { get; set; }
        }
    public class ProjectViewModel : ProjectModel
    {
        public string CommunityName { get; set; }
        public string DesignationName { get; set; }
        public string StaffName { get; set; }
        public string Status { get; set; }
    }
}
