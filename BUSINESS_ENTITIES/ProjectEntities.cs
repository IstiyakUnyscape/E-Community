using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class ProjectEntities
    {
        public string Id { get; set; }
        public int Community { get; set; }
        public int Designation { get; set; }
        public int? Name { get; set; }
        public string Project_Description { get; set; }
        public DateTime Estimated_StartDate { get; set; }
        public DateTime Estimated_EndDate { get; set; }
        public int Duration { get; set; }
        public Decimal Estimated_TotaleCost { get; set; }
        public string Upload_Document { get; set; }
        public bool Show_EstimatedCost { get; set; }
        public int StatusTypeDetailId { get; set; }
        public string ReasonOnHold { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
    }
    public class ProjectViewModelEntities : ProjectEntities
    {
        public string CommunityName { get; set; }
        public string DesignationName { get; set; }
        public string StaffName { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int TenantID { get; set; }
        public int TenantTypeId { get; set; }
    }
}
