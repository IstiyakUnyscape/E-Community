using BUSINESS_ENTITIES;
using DapperServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_ACCESS_LAYAR_INTERFACE
{
    public interface ICommonApiDAL
    {
        IEnumerable<CountryEntities> GetCountry();
        IEnumerable<StateEntities> GetState(int id);
        IEnumerable<CityEntities> GetCity(int id);
        IEnumerable<ServiceEntities> GetService();
        IEnumerable<DesignationEntities> GetDesignation();
        IEnumerable<Type_Of_VisitEntities> GetVisitType();
        IEnumerable<Type_of_DeliveryEntities> GetDeliveryType();
        IEnumerable<TypeMasterDetailEntities> GetTypeMasterDetail();

    }
}
