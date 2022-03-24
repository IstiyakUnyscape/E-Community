using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class DeveloperEntities
    {
        public string Id { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public long Mobile_No { get; set; }
        public string Email_Id { get; set; }
        public string Address { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Postal_Code { get; set; }
        public string Contact_Person { get; set; }
        public string License_Document { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int TenantTypeId { get; set; }
        public int TenantID { get; set; }
    }
    public class DeveloperViewEntities : DeveloperEntities
    {
        public string Country_Name { get; set; }
        public string State_Name { get; set; }
        public string City_Name { get; set; }
        public int UserId { get; set; }
    }
}
