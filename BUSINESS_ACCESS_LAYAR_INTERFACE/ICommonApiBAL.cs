using BUSINESS_ENTITIES;
using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface ICommonApiBAL
    {
        public IEnumerable<CountryEntities> GetCountry();
        public IEnumerable<StateEntities> GetState(int id);
        public IEnumerable<CityEntities> GetCity(int id);
        public IEnumerable<DesignationEntities> GetDesignation();
        public IEnumerable<ServiceEntities> GetService();
        public IEnumerable<Type_Of_VisitEntities> GetVisitType();
        public IEnumerable<Type_of_DeliveryEntities> GetDeliveryType();
        public IEnumerable<TypeMasterDetailEntities> GetTypeMasterDetail();
        public IEnumerable<CommunityEntities> GetCommunity();
        public IEnumerable<DesignationEntities> GetDesignationByTenantId(int TenantTypeId, int TenantId); 
        public IEnumerable<StaffEntity> GetStaffByDesignationId(int id);
        public IEnumerable<StaffEntity> GetStaff();
        public IEnumerable<UnitEntities> GetUnit();
        public IEnumerable<MenuEntities> GetMenuByRoleId(int Roleid);

    }
}
