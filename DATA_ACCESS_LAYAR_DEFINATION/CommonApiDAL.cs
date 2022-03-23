using BUSINESS_ENTITIES;
using Dapper;
using DapperServices;
using DATA_ACCESS_LAYAR_INTERFACE;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_ACCESS_LAYAR_DEFINATION
{
    public class CommonApiDAL : ICommonApiDAL
    {

        private readonly IDapper _dapper;
        public CommonApiDAL()
        {
            _dapper = new Dapperr();
        }


        //public async Task<List<T>> Get(int id)
        //{
        //    var query = "SELECT * FROM State WHERE Country_id = @Id";
        //    return await _GenericRepository.GetByIdAsync(id, query);
        //}

        //public async Task<List<T>> GetAll()
        //{
        //    var query = "SELECT * FROM Products";
        //    return await _GenericRepository.GetAllAsync(query);
        //}

        public IEnumerable<CityEntities> GetCity(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = _dapper.GetAll<CityEntities>("sp_GetCityByStateId", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }
        public IEnumerable<StateEntities> GetState(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = _dapper.GetAll<StateEntities>("sp_GetStateByCountryId", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<CountryEntities> GetCountry()
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            var res = _dapper.GetAll<CountryEntities>("sp_GetCountry", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<DesignationEntities> GetDesignation()
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            var res = _dapper.GetAll<DesignationEntities>("sp_GetDesignation", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<ServiceEntities> GetService()
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            var res = _dapper.GetAll<ServiceEntities>("sp_GetServices", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Type_Of_VisitEntities> GetVisitType()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<Type_Of_VisitEntities>("sp_GetType_Of_Visit", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Type_of_DeliveryEntities> GetDeliveryType()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<Type_of_DeliveryEntities>("sp_GetType_of_Delivery", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<TypeMasterDetailEntities> GetTypeMasterDetail()
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            var res = _dapper.GetAll<TypeMasterDetailEntities>("sp_TypeMasterDetail", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<StaffEntities> GetStaff()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<StaffEntities>("sp_GetStaff", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }
        public IEnumerable<VendorsEntities> GetVendor()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<VendorsEntities>("sp_GetVendors", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }
        public IEnumerable<UnitEntities> GetUnit()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<UnitEntities>("sp_GetUnit", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }
        public IEnumerable<MenuEntities> GetMenuByRoleId(int Roleid)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Roleid", Roleid, DbType.Int32);
            var res = _dapper.GetAll<MenuEntities>("sp_GetMenuByRoleId", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }
    }
}
