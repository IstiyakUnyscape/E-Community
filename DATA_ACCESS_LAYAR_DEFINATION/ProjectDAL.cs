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
    public class ProjectDAL : IProjectDAL
    {
        private readonly IDapper _dapper;
        public ProjectDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(ProjectEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Community", entity.Community);
            dbparams.Add("Designation", entity.Designation);
            dbparams.Add("Name", entity.Name);
            dbparams.Add("Project_Description", entity.Project_Description);
            dbparams.Add("Estimated_StartDate", entity.Estimated_StartDate);
            dbparams.Add("Estimated_EndDate", entity.Estimated_EndDate);
            dbparams.Add("Duration", entity.Duration);
            dbparams.Add("Estimated_TotaleCost", entity.Estimated_TotaleCost);
            dbparams.Add("Upload_Document", entity.Upload_Document);
            dbparams.Add("Show_EstimatedCost", entity.Show_EstimatedCost);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertProject", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteProject", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<ProjectEntities> GetAll(SearchCompanyEntities search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<ProjectEntities> result = _dapper.GetAll<ProjectEntities>("sp_GetProject", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
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
            IOrderedQueryable<ProjectEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(ProjectEntities);
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

        public IPagedList<ProjectViewModelEntities> GetAllProject(SearchCompanyEntities search)
        {
            var query = "select * from vw_Project";
            IQueryable<ProjectViewModelEntities> result = _dapper.GetAll<ProjectViewModelEntities>(query).Distinct().AsQueryable();
            if (search.UserId >0)
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
            IOrderedQueryable<ProjectViewModelEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(ProjectEntities);
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

        public async Task<ProjectEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<ProjectEntities>("sp_GetProjectById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(ProjectEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("Community", entity.Community);
            dbparams.Add("Designation", entity.Designation);
            dbparams.Add("Name", entity.Name);
            dbparams.Add("Project_Description", entity.Project_Description);
            dbparams.Add("Estimated_StartDate", entity.Estimated_StartDate);
            dbparams.Add("Estimated_EndDate", entity.Estimated_EndDate);
            dbparams.Add("Duration", entity.Duration);
            dbparams.Add("Estimated_TotaleCost", entity.Estimated_TotaleCost);
            dbparams.Add("Upload_Document", entity.Upload_Document);
            dbparams.Add("Show_EstimatedCost", entity.Show_EstimatedCost);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("StatusTypeDetailId", entity.StatusTypeDetailId);
            dbparams.Add("ReasonOnHold", entity.ReasonOnHold);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateProject", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
