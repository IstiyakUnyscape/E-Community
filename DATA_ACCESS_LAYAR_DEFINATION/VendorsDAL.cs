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
    public class VendorsDAL : IVendorsDAL
    {
        private readonly IDapper _dapper;
        public VendorsDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(VendorsEntities entity)
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
            dbparams.Add("Bank_Name", entity.Bank_Name);
            dbparams.Add("Bank_Address", entity.Bank_Address);
            dbparams.Add("Account_Name", entity.Account_Name);
            dbparams.Add("Account_Number", entity.Account_Number);
            dbparams.Add("IBAN_Number", entity.IBAN_Number);
            dbparams.Add("SWIFT_Code", entity.SWIFT_Code);
            dbparams.Add("Third_Party_Liability_Insurance_Copy", entity.Third_Party_Liability_Insurance_Copy);
            dbparams.Add("Third_Party_Liability_Insurance_Copy_ExpiryDate", entity.Third_Party_Liability_Insurance_Copy_ExpiryDate);
            dbparams.Add("Workmen_Compensation_Insurance_Copy", entity.Workmen_Compensation_Insurance_Copy);
            dbparams.Add("Workmen_Compensation_Insurance_ExpiryDate", entity.Workmen_Compensation_Insurance_ExpiryDate);
            dbparams.Add("Additional_Insurance", entity.Additional_Insurance);
            dbparams.Add("Additional_Insurance_ExpiryDate", entity.Additional_Insurance_ExpiryDate);
            dbparams.Add("Additional_Certificate", entity.Additional_Certificate);
            dbparams.Add("Additional_Certificate_Title", entity.Additional_Certificate_Title);
            dbparams.Add("Additional_Certificate_ExpiryDate", entity.Additional_Certificate_ExpiryDate);
            dbparams.Add("Service_Type", entity.Service_Type);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            //dbparams.Add("retVal", DbType.Int32, direction: ParameterDirection.Output);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertVendors", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteVendors", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<VendorsEntities> GetAll(SearchCompanyModel search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<VendorsEntities> result = _dapper.GetAll<VendorsEntities>("sp_GetVendors", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
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
            IOrderedQueryable<VendorsEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(VendorsEntities);
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

        public VendorsEntities GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = _dapper.Get<VendorsEntities>("sp_GetVendorById", dbparams, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Update(VendorsEntities entity)
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
            dbparams.Add("Bank_Name", entity.Bank_Name);
            dbparams.Add("Bank_Address", entity.Bank_Address);
            dbparams.Add("Account_Name", entity.Account_Name);
            dbparams.Add("Account_Number", entity.Account_Number);
            dbparams.Add("IBAN_Number", entity.IBAN_Number);
            dbparams.Add("SWIFT_Code", entity.SWIFT_Code);
            dbparams.Add("Third_Party_Liability_Insurance_Copy", entity.Third_Party_Liability_Insurance_Copy);
            dbparams.Add("Third_Party_Liability_Insurance_Copy_ExpiryDate", entity.Third_Party_Liability_Insurance_Copy_ExpiryDate);
            dbparams.Add("Workmen_Compensation_Insurance_Copy", entity.Workmen_Compensation_Insurance_Copy);
            dbparams.Add("Workmen_Compensation_Insurance_ExpiryDate", entity.Workmen_Compensation_Insurance_ExpiryDate);
            dbparams.Add("Additional_Insurance", entity.Additional_Insurance);
            dbparams.Add("Additional_Insurance_ExpiryDate", entity.Additional_Insurance_ExpiryDate);
            dbparams.Add("Additional_Certificate", entity.Additional_Certificate);
            dbparams.Add("Additional_Certificate_Title", entity.Additional_Certificate_Title);
            dbparams.Add("Additional_Certificate_ExpiryDate", entity.Additional_Certificate_ExpiryDate);
            dbparams.Add("Service_Type", entity.Service_Type);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("Isactive", true);
            //dbparams.Add("Isdeleted", entity.Isdeleted);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateVendors", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
