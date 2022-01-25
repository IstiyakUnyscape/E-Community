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
    public class StaffDAL : IStaffDAL
    {
        private readonly IDapper _dapper;
        public StaffDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(StaffEntities entity)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("F_Name", entity.F_Name);
            dbparams.Add("M_Name", entity.M_Name);
            dbparams.Add("L_Name", entity.L_Name);
            dbparams.Add("Mobile_No", entity.Mobile_No);
            dbparams.Add("Email_Id", entity.Email_Id);
            dbparams.Add("Designation", entity.Designation);
            dbparams.Add("Reporting_To", entity.Reporting_To);
            dbparams.Add("Address", entity.Address);
            dbparams.Add("Country_id", entity.Country);
            dbparams.Add("State_id", entity.State);
            dbparams.Add("City_id", entity.City);
            dbparams.Add("Postal_Code", entity.Postal_Code);
            dbparams.Add("Community", entity.Community);
            dbparams.Add("Identification_CardNo", entity.Identification_CardNo);
            dbparams.Add("ID_expiry_Date", entity.ID_expiry_Date);
            dbparams.Add("ID_upload_Picture", entity.ID_upload_Picture);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertStaff", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<int>("sp_DeleteStaff", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<StaffEntities> GetAll(SearchStaffModel search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<StaffEntities> result = _dapper.GetAll<StaffEntities>("sp_GetStaff", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
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
            IOrderedQueryable<StaffEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(StaffEntities);
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

        public StaffEntities GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = _dapper.Get<StaffEntities>("sp_GetStaffById", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Update(StaffEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("F_Name", entity.F_Name);
            dbparams.Add("M_Name", entity.M_Name);
            dbparams.Add("L_Name", entity.L_Name);
            dbparams.Add("Mobile_No", entity.Mobile_No);
            dbparams.Add("Email_Id", entity.Email_Id);
            dbparams.Add("Designation", entity.Designation);
            dbparams.Add("Reporting_To", entity.Reporting_To);
            dbparams.Add("Address", entity.Address);
            dbparams.Add("Country_id", entity.Country);
            dbparams.Add("State_id", entity.State);
            dbparams.Add("City_id", entity.City);
            dbparams.Add("Postal_Code", entity.Postal_Code);
            dbparams.Add("Community", entity.Community);
            dbparams.Add("Identification_CardNo", entity.Identification_CardNo);
            dbparams.Add("ID_expiry_Date", entity.ID_expiry_Date);
            dbparams.Add("ID_upload_Picture", entity.ID_upload_Picture);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("Isactive", true);
            //dbparams.Add("Isdeleted", entity.Isdeleted);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateStaff", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
