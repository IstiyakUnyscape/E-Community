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
    public class NoticesDAL : INoticesDAL
    {
        private readonly IDapper _dapper;
        public NoticesDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(NoticesEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Title", entity.Title);
            dbparams.Add("Description", entity.Description);
            dbparams.Add("Community", entity.Community);
            dbparams.Add("Unit", entity.Unit);
            dbparams.Add("StartDate", entity.StartDate, System.Data.DbType.Date);
            dbparams.Add("EndDate", entity.EndDate, System.Data.DbType.Date);
            dbparams.Add("StartTime", entity.StartTime, System.Data.DbType.Time);
            dbparams.Add("EndTime", entity.EndTime, System.Data.DbType.Time);
            dbparams.Add("UploadDocument", entity.UploadDocument);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertNotices", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteNotices", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<NoticesViewEntities> GetAll(SearchCompanyEntities search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<NoticesViewEntities> result = _dapper.GetAll<NoticesViewEntities>("sp_GetNotices", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
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
            }
            //if (!string.IsNullOrEmpty(search.Name))
            //{
            //    result = result.Where(x => x.Title.Trim().ToUpper() == search.Name.Trim().ToUpper());
            //}
            //if (!string.IsNullOrEmpty(search.Company_Email))
            //{
            //    result = result.Where(x => x.Company_Email_Id.Trim().ToUpper() == search.Company_Email.Trim().ToUpper());
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
            IOrderedQueryable<NoticesViewEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(NoticesViewEntities);
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

        public async Task<NoticesEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<NoticesEntities>("sp_GetNoticesById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(NoticesEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("Title", entity.Title);
            dbparams.Add("Description", entity.Description);
            dbparams.Add("Community", entity.Community);
            dbparams.Add("Unit", entity.Unit);
            dbparams.Add("StartDate", entity.StartDate, System.Data.DbType.Date);
            dbparams.Add("EndDate", entity.EndDate, System.Data.DbType.Date);
            dbparams.Add("StartTime", entity.StartTime, System.Data.DbType.Time);
            dbparams.Add("EndTime", entity.EndTime, System.Data.DbType.Time);
            dbparams.Add("UploadDocument", entity.UploadDocument);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);
            dbparams.Add("Isactive", true);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateNotices", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
