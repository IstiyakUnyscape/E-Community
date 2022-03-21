using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class RiskRegistryModel
    {
        public string Id { get; set; }
        [Required]
        public int CommunityId { get; set; }
        [Required]
        public int RiskCatagory { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public string Risk_Discription { get; set; }
        [Required]
        public int Assigned_To { get; set; }
        [Required]
        public int Risk_Probability { get; set; }
        [Required]
        public int Business_Imapact { get; set; }
        [Required]
        public int Risk_Rate { get; set; }
        [Required]
        public int Risk_Staus { get; set; }
        [Required]
        public string Risk_Treatment { get; set; }
        [Required]
        public string ContingencyPlan { get; set; }
        [Required]
        public string Mitigation { get; set; }
        [Required]
        public DateTime RaisedOn { get; set; }
        [Required]
        public DateTime ClosedOn { get; set; }
        [Required]
        public DateTime Target_Closure_date { get; set; }
        [Required]
        public string Reason_For_Closure { get; set; }
        public List<IFormFile> Upload_Document_File { get; set; }
        public string Upload_Document { get; set; }

        public int? StatusTypeDetailId { get; set; }
        public string Remarks { get; set; }
        // public DateTime Created_at { get; set; }
        public string CreatedBy { get; set; }
        //public DateTime? Modified_at { get; set; }
        public string ModifiedBy { get; set; }
        //public bool Isactive { get; set; }
        //public bool Isdeleted { get; set; }
        public bool IsProject { get; set; }
    }
    public class RiskRegistryViewModel : RiskRegistryModel
    {
        public string CommunityName { get; set; }
        public string Risk_Category_Name { get; set; }
        public string OwnerName { get; set; }
        public string Assigned_To_StaffName { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int TenantID { get; set; }
        public int TenantTypeId { get; set; }
    }
}
