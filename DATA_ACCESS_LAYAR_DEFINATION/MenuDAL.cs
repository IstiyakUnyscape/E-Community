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
    public class MenuDAL : IMenuDAL
    {
        private readonly Dapperr _dapper;
        public MenuDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(MenuEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Menu_Display_Name", entity.Menu_Display_Name);
            dbparams.Add("Logical_Name", entity.Logical_Name);
            dbparams.Add("ParentID", entity.ParentID);
            dbparams.Add("Controller_Name", entity.Controller_Name);
            dbparams.Add("ActionName", entity.ActionName);
            dbparams.Add("Http_Method", entity.Http_Method);
            dbparams.Add("Optional_RouteValues", entity.Optional_RouteValues);            
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertMenu", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteMenu", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<MenuEntities> GetAll(SearchCompanyModel search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<MenuEntities> result = _dapper.GetAll<MenuEntities>("sp_GetMenu", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
           
            IOrderedQueryable<MenuEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(MenuEntities);
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
                    OrderedQuery = result.OrderByDescending(x => x.id);
                }
            }
            else
            {
                OrderedQuery = result.OrderByDescending(x => x.id);
            }
            return OrderedQuery.ToPagedList(search.PageNo, search.PageSize);
        }

        public IEnumerable<MilestoneViewEntities> GetAll()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<MilestoneViewEntities>("vw_Milestone", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<MenuEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<MenuEntities>("sp_GetMenuById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(MenuEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.id));
            dbparams.Add("Menu_Display_Name", entity.Menu_Display_Name);
            dbparams.Add("Logical_Name", entity.Logical_Name);
            dbparams.Add("ParentID", entity.ParentID);
            dbparams.Add("Controller_Name", entity.Controller_Name);
            dbparams.Add("ActionName", entity.ActionName);
            dbparams.Add("Http_Method", entity.Http_Method);
            dbparams.Add("Optional_RouteValues", entity.Optional_RouteValues);            
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);
            dbparams.Add("Isactive", true);            
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateMenu", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
