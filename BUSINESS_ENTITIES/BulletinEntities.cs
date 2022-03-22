using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class BulletinEntities
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Upload_Pictures { get; set; }
        public string Attach_Documents { get; set; }
        public long Mobile_No { get; set; }
        public string EmailId { get; set; }
        public decimal? Price { get; set; }
        public string Availability_To_Contact { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public bool IsShowAdmin { get; set; }
        public int? StatusTypeDetailID { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Remarks { get; set; }
    }
    public class BulletinViewEntities
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Upload_Pictures { get; set; }
        public string Attach_Documents { get; set; }
        public long Mobile_No { get; set; }
        public string EmailId { get; set; }
        public decimal? Price { get; set; }
        public string Availability_To_Contact { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public bool IsShowAdmin { get; set; }
        public string StatusTypeDetailID { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Remarks { get; set; }
    }
}
