using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class GuestEntities
    {
        public string id { get; set; }
        public string F_Name { get; set; }
        public string M_Name { get; set; }
        public string L_Name { get; set; }
        public string Email_id { get; set; }
        public long Mobile_No { get; set; }
        public int Type_of_Visit { get; set; }
        public string Community { get; set; }
        public int Floor { get; set; }
        public int Unit { get; set; }
        public DateTime Date_of_visit { get; set; }
        public DateTime Time_of_visit { get; set; }
        public string Purpose_of_the_visit { get; set; }
        public bool Parking_required { get; set; }
        public string Car_model_details { get; set; }
        public string Plate_No { get; set; }
        public string Car_Registration_Card { get; set; }
        public string ID_No { get; set; }
        public string Upload_ID_No { get; set; }
        public string Delivery_company_Name { get; set; }
        public string Delivery_Staff_Name { get; set; }
        public string Staff_ID_Card_No { get; set; }
        public string Staff_ID_Card_Image { get; set; }
        public int Type_of_Delivery { get; set; }
        public string Company_Name { get; set; }
        public int Number_of_Staff_to_Reach_the_Unit { get; set; }
        public string Scope_of_Work { get; set; }
        public string Materials_carrie_in { get; set; }
        public string Service_Provider_Staff_Name { get; set; }
        public long Staff_Mobile_Number { get; set; }
        public string Staff_ID_Card_image1 { get; set; }
        public string Staff_ID_Card_image2 { get; set; }
        public string Staff_ID_Card_image3 { get; set; }
        public string Staff_ID_Card_image4 { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public string Profile_Image { get; set; }
    }
}
