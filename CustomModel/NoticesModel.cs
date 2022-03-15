using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class NoticesModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Community { get; set; }
        public string Unit { get; set; }
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
        //public TimeSpan? StartTime { get; set; }
        //public TimeSpan? EndTime { get; set; }
        public string UploadDocument { get; set; }
        public IFormFile Upload_Document_File { get; set; }
        //public DateTime Created_at { get; set; }
        public string CreatedBy { get; set; }
        //public DateTime? Modified_at { get; set; }
        public string ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        //public bool Isdeleted { get; set; }
    }
}
