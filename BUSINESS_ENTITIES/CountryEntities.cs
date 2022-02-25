using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class CountryEntities
    {
        public int id { get; set; }
        public string Country_Name { get; set; }
    }
    public class StateEntities
    {
        public int id { get; set; }
        public string State_Name { get; set; }
        public int Country_id { get; set; }
    }
    public class CityEntities
    {
        public int id { get; set; }
        public string City_Name { get; set; }
        public int State_id { get; set; }
    }
 
    public class ServiceEntities
    {
        public int id { get; set; }
        public string Service { get; set; }

    }
    public class Type_Of_VisitEntities
    {
        public int id { get; set; }
        public string Visit_Type { get; set; }

    }
    public class Type_of_DeliveryEntities
    {
        public int id { get; set; }
        public string Delivery_Type { get; set; }

    }
    public class TypeMasterDetailEntities
    {
        public int TypeMaster_Id { get; set; }
        public string TypeMasterCode { get; set; }
        public bool IsTypeMasterActive { get; set; }
        public int TypeDetail_Id { get; set; }
        public string TypeDetailCode { get; set; }
        public bool IsTypeDetailActive { get; set; }
        public int Sequence { get; set; }

    }
}
