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
    public class CompaniesDAL : ICompaniesDAL
    {
        private readonly Dapperr _dapper;
        public CompaniesDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(CompanyEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Company_Name", entity.Company_Name);
            dbparams.Add("Company_Address", entity.Company_Address);
            dbparams.Add("Country_id", entity.Country);
            dbparams.Add("State_id", entity.State);
            dbparams.Add("City_id", entity.City);
            dbparams.Add("Postal_Code", entity.Postal_Code);
            dbparams.Add("Owner_Fname", entity.Owner_Fname);
            dbparams.Add("Owner_Lname", entity.Owner_Lname);
            dbparams.Add("Owner_MobileNo", entity.Owner_MobileNo);
            dbparams.Add("Owner_Email_ID", entity.Owner_Email_ID);
            dbparams.Add("Owner_Nationality", entity.Owner_Nationality);
            dbparams.Add("Company_LandlineNo", entity.Company_LandlineNo);
            dbparams.Add("Company_Website", entity.Company_Website);
            dbparams.Add("Company_Email_Id", entity.Company_Email_Id);
            dbparams.Add("Trade_License_No", entity.Trade_License_No);
            dbparams.Add("Tradelicense_Expiry_Date", entity.Tradelicense_Expiry_Date);
            dbparams.Add("Tradelicense_Copy", entity.Tradelicense_Copy);
            dbparams.Add("Tax_Return_Number", entity.Tax_Return_Number);
            dbparams.Add("TRN_Certificate", entity.TRN_Certificate);
            dbparams.Add("Owner_Passport_Copy", entity.Owner_Passport_Copy);
            dbparams.Add("Owner_Visa_Copy", entity.Owner_Visa_Copy);
            dbparams.Add("Number_of_Communities_Managed", entity.Number_of_Communities_Managed);
            dbparams.Add("Total_Managed_Common_Area", entity.Total_Managed_Common_Area);
            dbparams.Add("Additional_Certificates", entity.Additional_Certificates);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            dbparams.Add("Country_Code", entity.Country_Code);
            dbparams.Add("Std_Code", entity.Std_Code);
            dbparams.Add("TenantTypeId", entity.TenantTypeId);
            dbparams.Add("Profile_Image", entity.Profile_Image);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertCompanies", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteCompanies", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<CompanyEntities> GetAll(SearchCompanyModel search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<CompanyEntities> result = _dapper.GetAll<CompanyEntities>("sp_GetCompanies", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                result = result.Where(x => x.Company_Name.Trim().ToUpper() == search.Name.Trim().ToUpper());
            }
            if (!string.IsNullOrEmpty(search.Company_Email))
            {
                result = result.Where(x => x.Company_Email_Id.Trim().ToUpper() == search.Company_Email.Trim().ToUpper());
            }
            if (!string.IsNullOrEmpty(search.Postal_Code))
            {
                result = result.Where(x => x.Postal_Code.Trim().ToUpper() == search.Postal_Code.Trim().ToUpper());
            }
            if (!string.IsNullOrEmpty(search.Postal_Code))
            {
                result = result.Where(x => x.Postal_Code.Trim().ToUpper() == search.Postal_Code.Trim().ToUpper());
            }
            if (!string.IsNullOrEmpty(search.Trade_License_No))
            {
                result = result.Where(x => x.Trade_License_No.Trim().ToUpper() == search.Trade_License_No.Trim().ToUpper());
            }
            if (search.Tax_Return_Number > 0)
            {
                result = result.Where(x => x.Tax_Return_Number == search.Tax_Return_Number);
            }
            IOrderedQueryable<CompanyEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(CompanyEntities);
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

        public async Task<CompanyEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<CompanyEntities>("sp_GetCompanyById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(CompanyEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("Company_Name", entity.Company_Name);
            dbparams.Add("Company_Address", entity.Company_Address);
            dbparams.Add("Country_id", entity.Country);
            dbparams.Add("State_id", entity.State);
            dbparams.Add("City_id", entity.City);
            dbparams.Add("Postal_Code", entity.Postal_Code);
            dbparams.Add("Owner_Fname", entity.Owner_Fname);
            dbparams.Add("Owner_Lname", entity.Owner_Lname);
            dbparams.Add("Owner_MobileNo", entity.Owner_MobileNo);
            dbparams.Add("Owner_Email_ID", entity.Owner_Email_ID);
            dbparams.Add("Owner_Nationality", entity.Owner_Nationality);
            dbparams.Add("Company_LandlineNo", entity.Company_LandlineNo);
            dbparams.Add("Company_Website", entity.Company_Website);
            dbparams.Add("Company_Email_Id", entity.Company_Email_Id);
            dbparams.Add("Trade_License_No", entity.Trade_License_No);
            dbparams.Add("Tradelicense_Expiry_Date", entity.Tradelicense_Expiry_Date);
            dbparams.Add("Tradelicense_Copy", entity.Tradelicense_Copy);
            dbparams.Add("Tax_Return_Number", entity.Tax_Return_Number);
            dbparams.Add("TRN_Certificate", entity.TRN_Certificate);
            dbparams.Add("Owner_Passport_Copy", entity.Owner_Passport_Copy);
            dbparams.Add("Owner_Visa_Copy", entity.Owner_Visa_Copy);
            dbparams.Add("Number_of_Communities_Managed", entity.Number_of_Communities_Managed);
            dbparams.Add("Total_Managed_Common_Area", entity.Total_Managed_Common_Area);
            dbparams.Add("Additional_Certificates", entity.Additional_Certificates);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Country_Code", entity.Country_Code);
            dbparams.Add("Std_Code", entity.Std_Code);
            dbparams.Add("StatusTypeDetailID", entity.StatusTypeDetailID);
            dbparams.Add("ApprovedDate", entity.ApprovedDate);
            dbparams.Add("Remarks", entity.Remarks);
            dbparams.Add("IsShowAdmin", entity.IsShowAdmin);
            dbparams.Add("Profile_Image", entity.Profile_Image);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateCompanies", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        IEnumerable<CompanyEntities> ICompaniesDAL.GetAll()
        {
            var dbparams = new DynamicParameters();
            var res = _dapper.GetAll<CompanyEntities>("sp_GetCompanies", dbparams, commandType: CommandType.StoredProcedure).AsEnumerable();
            return res;
        }
    }

}
