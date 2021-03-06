using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using CustomModel;
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
        public IEnumerable<CommunityEntities> GetCommunity()
        {
            List<CommunityEntities> communities = new List<CommunityEntities>
            {
            new CommunityEntities { Id = 1, CommunityName = "Axis Residencess1" },
            new CommunityEntities { Id = 2, CommunityName = "Axis Residencess2"},
            new CommunityEntities { Id = 3, CommunityName = "Axis Residencess3"}
            };
           
            return communities;
        }

        public IEnumerable<DesignationEntities> GetDesignationByTenantId(int TenantTypeId, int TenantId)
        {
            return _CommonApiDAL.GetDesignation().Where(x=>x.TenantTypeID== TenantTypeId && x.TenantID==TenantId);
        }

        public IEnumerable<StaffEntity> GetStaffByDesignationId(int id)
        {
            var res= _CommonApiDAL.GetStaff().Where(x=>x.Designation==id);
            List<StaffEntity> entity = new List<StaffEntity>();
            foreach(var obj in res)
            {
                StaffEntity staffEntity = new StaffEntity();
                staffEntity.Id = Convert.ToInt32(obj.Id);
                staffEntity.Name = obj.F_Name +" "+ obj.L_Name;
                entity.Add(staffEntity);
            }
            return entity;
        }
        public IEnumerable<UnitEntities> GetUnit()
        {
            return _CommonApiDAL.GetUnit();
}
        public IEnumerable<MenuEntities> GetMenuByRoleId(int Roleid)
        {

            var res = _CommonApiDAL.GetMenuByRoleId(Roleid);
            foreach (var list in res)
            {
                list.Url = list.Controller_Name + "/" + list.ActionName + "/" + list.Optional_RouteValues;
            }
            return res;
        }

        public IEnumerable<StaffEntity> GetStaff()
        {
            var res = _CommonApiDAL.GetStaff();
            List<StaffEntity> entity = new List<StaffEntity>();
            foreach (var obj in res)
            {
                StaffEntity staffEntity = new StaffEntity();
                staffEntity.Id = Convert.ToInt32(obj.Id);
                staffEntity.Name = obj.F_Name + " " + obj.L_Name;
                entity.Add(staffEntity);
            }
            return entity;
        }

        public IEnumerable<VendorsEntity> GetVendor()
        {
            var res = _CommonApiDAL.GetVendor();
            List<VendorsEntity> entity = new List<VendorsEntity>();
            foreach (var obj in res)
            {
                VendorsEntity vendorsEntity = new VendorsEntity();
                vendorsEntity.Id = Convert.ToInt32(obj.Id);
                vendorsEntity.Name = obj.Company_Name; 
                entity.Add(vendorsEntity);
            }
            return entity;
        }
    }
}
