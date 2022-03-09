using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class RiskRegistryEntities
    {
        public string Id { get; set; }
        public int CommunityId { get; set; }
        public int RiskCatagory { get; set; }
        public int OwnerId { get; set; }
        public string Risk_Discription { get; set; }
        public int Assigned_To { get; set; }
        public int Risk_Probability { get; set; }
        public int Business_Imapact { get; set; }
        public int Risk_Rate { get; set; }
        public int Risk_Staus { get; set; }
        public string Risk_Treatment { get; set; }
        public string ContingencyPlan { get; set; }
        public string Mitigation { get; set; }
        public DateTime RaisedOn { get; set; }
        public DateTime ClosedOn { get; set; }
        public DateTime Target_Closure_date { get; set; }
        public string Reason_For_Closure { get; set; }
        public string Upload_Document { get; set; }
        public int StatusTypeDetailId { get; set; }
        public string Remarks { get; set; }
        public DateTime Created_at { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified_at { get; set; }
        public int ModifiedBy { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }

    }
}
