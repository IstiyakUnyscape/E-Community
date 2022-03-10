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
    public class RiskRegistryDAL: IRiskRegistryDAL
    {

        private readonly IDapper _dapper;
        public RiskRegistryDAL()
        {
            _dapper = new Dapperr();
        }

        public async Task<int> Create(RiskRegistryEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("CommunityId", entity.CommunityId);
            dbparams.Add("RiskCatagory", entity.RiskCatagory);
            dbparams.Add("OwnerId", entity.OwnerId);
            dbparams.Add("Risk_Discription", entity.Risk_Discription);
            dbparams.Add("Assigned_To", entity.Assigned_To);
            dbparams.Add("Risk_Probability", entity.Risk_Probability);
            dbparams.Add("Business_Imapact", entity.Business_Imapact);
            dbparams.Add("Risk_Rate", entity.Risk_Rate);
            dbparams.Add("Risk_Staus", entity.Risk_Staus);
            dbparams.Add("Risk_Treatment", entity.Risk_Treatment);
            dbparams.Add("ContingencyPlan", entity.ContingencyPlan);
            dbparams.Add("Business_Imapact", entity.Business_Imapact);
            dbparams.Add("Mitigation", entity.Mitigation);
            dbparams.Add("RaisedOn", entity.RaisedOn);
            dbparams.Add("ClosedOn", entity.ClosedOn);
            dbparams.Add("Target_Closure_date", entity.Target_Closure_date);
            dbparams.Add("Reason_For_Closure", entity.Reason_For_Closure);
            dbparams.Add("Upload_Document", entity.Upload_Document);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            dbparams.Add("IsProject", entity.IsProject);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertRiskRegistry", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteRiskRegistry", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<RiskRegistryEntities> GetAll(SearchCompanyModel search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<RiskRegistryEntities> result = _dapper.GetAll<RiskRegistryEntities>("sp_GetRiskRegistry", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
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
            IOrderedQueryable<RiskRegistryEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(RiskRegistryEntities);
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

        public async Task<RiskRegistryEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<RiskRegistryEntities>("sp_GetRiskRegistryById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(RiskRegistryEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("CommunityId", entity.CommunityId);
            dbparams.Add("RiskCatagory", entity.RiskCatagory);
            dbparams.Add("OwnerId", entity.OwnerId);
            dbparams.Add("Risk_Discription", entity.Risk_Discription);
            dbparams.Add("Assigned_To", entity.Assigned_To);
            dbparams.Add("Risk_Probability", entity.Risk_Probability);
            dbparams.Add("Business_Imapact", entity.Business_Imapact);
            dbparams.Add("Risk_Rate", entity.Risk_Rate);
            dbparams.Add("Risk_Staus", entity.Risk_Staus);
            dbparams.Add("Risk_Treatment", entity.Risk_Treatment);
            dbparams.Add("ContingencyPlan", entity.ContingencyPlan);
            dbparams.Add("Business_Imapact", entity.Business_Imapact);
            dbparams.Add("Mitigation", entity.Mitigation);
            dbparams.Add("RaisedOn", entity.RaisedOn);
            dbparams.Add("ClosedOn", entity.ClosedOn);
            dbparams.Add("Target_Closure_date", entity.Target_Closure_date);
            dbparams.Add("Reason_For_Closure", entity.Reason_For_Closure);
            dbparams.Add("Upload_Document", entity.Upload_Document);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("StatusTypeDetailId", entity.StatusTypeDetailId);
            dbparams.Add("Remarks", entity.Remarks);
            dbparams.Add("IsProject", entity.IsProject);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateRiskRegistry", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
