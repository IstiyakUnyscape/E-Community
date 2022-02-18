using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using DATA_ACCESS_LAYAR_DEFINATION;
using DATA_ACCESS_LAYAR_INTERFACE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ACCESS_LAYAR_DEFINATION
{
    public class CommonApiBAL : ICommonApiBAL
    {
        private readonly ICommonApiDAL _CommonApiDAL;
        public CommonApiBAL()
        {
            _CommonApiDAL = new CommonApiDAL();
        }

        public IEnumerable<CityEntities> GetCity(int id)
        {
           return _CommonApiDAL.GetCity(id);
        }

        public IEnumerable<CountryEntities> GetCountry()
        {
          
                return  _CommonApiDAL.GetCountry();
        }
        public IEnumerable<DesignationEntities> GetDesignation()
        {
               return  _CommonApiDAL.GetDesignation();
        }

        public IEnumerable<ServiceEntities> GetService()
        {
           return  _CommonApiDAL.GetService();
        }
        public IEnumerable<StateEntities> GetState(int id)
        {
           return _CommonApiDAL.GetState(id);
        }

        public IEnumerable<Type_Of_VisitEntities> GetVisitType()
        {
            return _CommonApiDAL.GetVisitType();
        }
        public IEnumerable<Type_of_DeliveryEntities> GetDeliveryType()
        {
            return _CommonApiDAL.GetDeliveryType();
        }

        public IEnumerable<TypeMasterDetailEntities> GetTypeMasterDetail()
        {
            return _CommonApiDAL.GetTypeMasterDetail();
        }
    }
}
