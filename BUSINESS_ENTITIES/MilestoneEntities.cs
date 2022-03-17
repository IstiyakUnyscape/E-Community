using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class MilestoneEntities
    {
        public string Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Estimated_StartDate { get; set; }
        public DateTime Estimated_EndDate { get; set; }
        public int Estimated_Duration { get; set; }      
        public Decimal? Payment { get; set; }
        public float? Percentage { get; set; }
        public DateTime? Actual_StartDate { get; set; }
        public DateTime? Actual_EndDate { get; set; }
        public int? Actual_Duration { get; set; }
        public int? Assigned_To { get; set; }
        public DateTime? DeadLine { get; set; }
        public string Upload_Document { get; set; }
        public int? StatusTypeDetailId { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
    }
    public class MilestoneViewEntities : MilestoneEntities
    {
        public string Project_Description { get; set; }
        public string Assigned_To_StaffName { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int TenantID { get; set; }
        public int TenantTypeId { get; set; }
    }
}
