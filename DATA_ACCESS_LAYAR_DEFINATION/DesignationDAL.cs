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
    public class DesignationDAL : IDesignationDAL   
    {
        private readonly Dapperr _dapper;
        public DesignationDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(DesignationEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Designation", entity.Designation);
            dbparams.Add("DesignationDescription", entity.DesignationDescription);
            dbparams.Add("TenantTypeID", entity.TenantTypeID);
            dbparams.Add("TenantID", entity.TenantID);            
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);           
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertDesignation", dbparams, commandType: CommandType.StoredProcedure));
            return result;
            
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteDesignation", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<DesignationEntities> GetAll(SearchCompanyModel search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<DesignationEntities> result = _dapper.GetAll<DesignationEntities>("sp_GetDesignation", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
            //if (!string.IsNullOrEmpty(search.Name))
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
            IOrderedQueryable<DesignationEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(DesignationEntities);
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
                    OrderedQuery = result.OrderByDescending(x => Convert.ToInt32(x.id));
                }
            }
            else
            {
                OrderedQuery = result.OrderByDescending(x => Convert.ToInt32(x.id));
            }
            return OrderedQuery.ToPagedList(search.PageNo, search.PageSize);
        }

        public async Task<DesignationEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<DesignationEntities>("sp_GetDesignationById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(DesignationEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id",Convert.ToInt32(entity.id));
            dbparams.Add("Designation", entity.Designation);
            dbparams.Add("DesignationDescription", entity.DesignationDescription);
            dbparams.Add("TenantTypeID", entity.TenantTypeID);
            dbparams.Add("TenantID", entity.TenantID);
            //dbparams.Add("Isactive", true);
            //dbparams.Add("Isdeleted", false); CreatedBy
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);           
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateDesignation", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        IEnumerable<DesignationEntities> IDesignationDAL.GetAll()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<DesignationEntities>("sp_GetDesignation", dbparams, commandType: CommandType.StoredProcedure).AsEnumerable();
            return res;
        }
    }
}
