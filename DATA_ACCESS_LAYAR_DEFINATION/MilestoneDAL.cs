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
    public class MilestoneDAL : IMilestoneDAL
    {
        private readonly Dapperr _dapper;
        public MilestoneDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(MilestoneEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("ProjectId", entity.ProjectId);
            dbparams.Add("Title", entity.Title);
            dbparams.Add("Description", entity.Description);
            dbparams.Add("Estimated_StartDate", entity.Estimated_StartDate);
            dbparams.Add("Estimated_EndDate", entity.Estimated_EndDate);
            dbparams.Add("Estimated_Duration", entity.Estimated_Duration);
            dbparams.Add("Payment", entity.Payment);
            dbparams.Add("Percentage", entity.Percentage);
            dbparams.Add("Actual_StartDate", entity.Actual_StartDate);
            dbparams.Add("Actual_EndDate", entity.Actual_EndDate);
            dbparams.Add("Actual_Duration", entity.Actual_Duration);
            dbparams.Add("Assigned_To", entity.Assigned_To);
            dbparams.Add("DeadLine", entity.DeadLine);
            dbparams.Add("Upload_Document", entity.Upload_Document);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertMilestone", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteMilestone", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<MilestoneViewEntities> GetAll(SearchCompanyEntities search)
        {
            var query = "select * from vw_Milestone";
            IQueryable<MilestoneViewEntities> result = _dapper.GetAll<MilestoneViewEntities>(query).Distinct().AsQueryable();
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
            IOrderedQueryable<MilestoneViewEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(MilestoneViewEntities);
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

        public IEnumerable<MilestoneViewEntities> GetAll()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<MilestoneViewEntities>("vw_Milestone", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<MilestoneEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<MilestoneEntities>("sp_GetMilestoneById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(MilestoneEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("ProjectId", entity.ProjectId);
            dbparams.Add("Title", entity.Title);
            dbparams.Add("Description", entity.Description);
            dbparams.Add("Estimated_StartDate", entity.Estimated_StartDate);
            dbparams.Add("Estimated_EndDate", entity.Estimated_EndDate);
            dbparams.Add("Estimated_Duration", entity.Estimated_Duration);
            dbparams.Add("Payment", entity.Payment);
            dbparams.Add("Percentage", entity.Percentage);
            dbparams.Add("Actual_StartDate", entity.Actual_StartDate);
            dbparams.Add("Actual_EndDate", entity.Actual_EndDate);
            dbparams.Add("Actual_Duration", entity.Actual_Duration);
            dbparams.Add("Assigned_To", entity.Assigned_To);
            dbparams.Add("DeadLine", entity.DeadLine);
            dbparams.Add("Upload_Document", entity.Upload_Document);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("StatusTypeDetailId", entity.StatusTypeDetailId);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateMilestone", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
