using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class ProjectModel
    {
        public string Id { get; set; }
        public int Community { get; set; }
        public int Designation { get; set; }
        public string Name { get; set; }
        public string Project_Description { get; set; }
        public DateTime Estimated_StartDate { get; set; }
        public DateTime Estimated_EndDate { get; set; }
        public int Duration { get; set; }
        public Decimal Estimated_TotaleCost { get; set; }
        public List<IFormFile> Upload_Document_File { get; set; }
        public string Upload_Document { get; set; }
        public bool Show_EstimatedCost { get; set; }
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
}
