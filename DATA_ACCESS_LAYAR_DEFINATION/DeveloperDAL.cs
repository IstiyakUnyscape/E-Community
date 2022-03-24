using BUSINESS_ENTITIES;
using CustomModel;
using Dapper;
using DapperServices;
using DATA_ACCESS_LAYAR_INTERFACE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DATA_ACCESS_LAYAR_DEFINATION
{
    public class DeveloperDAL : IDeveloperDAL
    {
        private readonly IDapper _dapper;
        public DeveloperDAL()
        {
            _dapper = new Dapperr();
        }

        public async Task<int> Create(DeveloperEntities entity)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("F_Name", entity.F_Name);
            dbparams.Add("L_Name", entity.L_Name);
            dbparams.Add("Mobile_No", entity.Mobile_No);
            dbparams.Add("Email_Id", entity.Email_Id);
            dbparams.Add("Address", entity.Address);
            dbparams.Add("Country_id", entity.Country);
            dbparams.Add("State_id", entity.State);
            dbparams.Add("City_id", entity.City);
            dbparams.Add("Postal_Code", entity.Postal_Code);
            dbparams.Add("Contact_Person", entity.Contact_Person);
            dbparams.Add("License_Document", entity.License_Document);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("Isactive", true);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("TenantID", entity.TenantID);
            dbparams.Add("TenantTypeId", entity.TenantTypeId);

            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertDeveloper", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<int>("sp_DeleteDevelopers", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<DeveloperViewEntities> GetAll(SearchCompanyEntities search)
        {
            var query = "select * from vw_Developers";
            IQueryable<DeveloperViewEntities> result = _dapper.GetAll<DeveloperViewEntities>(query).Distinct().AsQueryable();
            if (search.UserId > 0)
            {
                result = result.Where(x => x.UserId == search.UserId);
            }
            if (search.TenantID > 0)
            {
                result = result.Where(x => x.TenantID == search.TenantID);
            }
            if (search.TenantTypeId > 0)
            {
                result = result.Where(x => x.TenantTypeId == search.TenantTypeId);
            }//if (!string.IsNullOrEmpty(search.Name))
            //{
            //    result = result.Where(x => x.F_Name.Trim().ToUpper() == search.Name.Trim().ToUpper());
            //}
            //if (!string.IsNullOrEmpty(search.Company_Email))
            //{
            //    result = result.Where(x => x.Email_Id.Trim().ToUpper() == search.Company_Email.Trim().ToUpper());
            //}
            //if (!string.IsNullOrEmpty(search.Postal_Code))
            //{
            //    result = result.Where(x => x.Postal_Code.Trim().ToUpper() == search.Postal_Code.Trim().ToUpper());
            //}
            //if (!string.IsNullOrEmpty(search.Postal_Code))
            //{
            //    result = result.Where(x => x.Postal_Code.Trim().ToUpper() == search.Postal_Code.Trim().ToUpper());
            //}
            //if (!string.IsNullOrEmpty(search.Trade_License_No))
            //{
            //    result = result.Where(x => x.Trade_License_No.Trim().ToUpper() == search.Trade_License_No.Trim().ToUpper());
            //}
            //if (search.Tax_Return_Number > 0)
            //{
            //    result = result.Where(x => x.Tax_Return_Number == search.Tax_Return_Number);
            //}
            IOrderedQueryable<DeveloperViewEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(DeveloperViewEntities);
                PropertyInfo property = type.GetProperty(search.SortColumn);
                if (property != null)
                {
                    if (search.SortDirection.ToUpper() == "desc".ToUpper())
                        OrderedQuery = result.OrderByDescending(search.SortColumn);
                    else
                        OrderedQuery = result.OrderBy(search.SortColumn);
                }
                else
                {
                    OrderedQuery = result.OrderByDescending(x => x.Id);
                }
            }
            else
            {
                OrderedQuery = result.OrderByDescending(x => x.Id);
            }
            return OrderedQuery.ToPagedList(search.PageNo, search.PageSize);
        }

        public async Task<DeveloperEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<DeveloperEntities>("sp_GetDeveloperById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(DeveloperEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("F_Name", entity.F_Name);
            dbparams.Add("L_Name", entity.L_Name);
            dbparams.Add("Mobile_No", entity.Mobile_No);
            dbparams.Add("Email_Id", entity.Email_Id);
            dbparams.Add("Address", entity.Address);
            dbparams.Add("Country_id", entity.Country);
            dbparams.Add("State_id", entity.State);
            dbparams.Add("City_id", entity.City);
            dbparams.Add("Postal_Code", entity.Postal_Code);
            dbparams.Add("Contact_Person", entity.Contact_Person);
            dbparams.Add("License_Document", entity.License_Document);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("Isactive", true);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);
            dbparams.Add("TenantID", entity.TenantID);
            dbparams.Add("TenantTypeId", entity.TenantTypeId);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateDeveloper", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
