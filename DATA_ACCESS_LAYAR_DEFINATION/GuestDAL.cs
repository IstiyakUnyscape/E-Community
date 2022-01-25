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
    public class GuestDAL : IGuestDAL
    {
        private readonly IDapper _dapper;
        public GuestDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(GuestEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("F_Name", entity.F_Name);
            dbparams.Add("M_Name", entity.M_Name);
            dbparams.Add("L_Name", entity.L_Name);
            dbparams.Add("Email_id", entity.Email_id);
            dbparams.Add("Mobile_No", entity.Mobile_No);
            dbparams.Add("Type_of_Visit", entity.Type_of_Visit);
            dbparams.Add("Community", entity.Community);
            dbparams.Add("Floor", entity.Floor);
            dbparams.Add("Date_of_visit", entity.Date_of_visit);
            dbparams.Add("Time_of_visit", entity.Time_of_visit);
            dbparams.Add("Purpose_of_the_visit", entity.Purpose_of_the_visit);
            dbparams.Add("Parking_required", entity.Parking_required);
            dbparams.Add("Car_model_details", entity.Car_model_details);
            dbparams.Add("Plate_No", entity.Plate_No);
            dbparams.Add("Car_Registration_Card", entity.Car_Registration_Card);
            dbparams.Add("ID_No", entity.ID_No);
            dbparams.Add("Upload_ID_No", entity.Upload_ID_No);
            dbparams.Add("Delivery_company_Name", entity.Delivery_company_Name);
            dbparams.Add("Delivery_Staff_Name", entity.Delivery_Staff_Name);
            dbparams.Add("Staff_ID_Card_No", entity.Staff_ID_Card_No);
            dbparams.Add("Staff_ID_Card_Image", entity.Staff_ID_Card_Image);
            dbparams.Add("Type_of_Delivery", entity.Type_of_Delivery);
            dbparams.Add("Company_Name", entity.Company_Name);
            dbparams.Add("Number_of_Staff_to_Reach_the_Unit", entity.Number_of_Staff_to_Reach_the_Unit);
            dbparams.Add("Scope_of_Work", entity.Scope_of_Work);
            dbparams.Add("Materials_carrie_in", entity.Materials_carrie_in);
            dbparams.Add("Service_Provider_Staff_Name", entity.Service_Provider_Staff_Name);
            dbparams.Add("Staff_Mobile_Number", entity.Staff_Mobile_Number);
            dbparams.Add("Staff_ID_Card_image1", entity.Staff_ID_Card_image1);
            dbparams.Add("Staff_ID_Card_image2", entity.Staff_ID_Card_image2);
            dbparams.Add("Staff_ID_Card_image3", entity.Staff_ID_Card_image3);
            dbparams.Add("Staff_ID_Card_image4", entity.Staff_ID_Card_image4);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            //dbparams.Add("retVal", DbType.Int32, direction: ParameterDirection.Output);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertGuest", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteGuest", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<GuestEntities> GetAll(SearchCompanyModel search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<GuestEntities> result = _dapper.GetAll<GuestEntities>("sp_GetGuest", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
            //if (!string.IsNullOrEmpty(search.Name))
            //{
            //    result = result.Where(x => x.Company_Name.Trim().ToUpper() == search.Name.Trim().ToUpper());
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
            IOrderedQueryable<GuestEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(GuestEntities);
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

        public async Task<GuestEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<GuestEntities>("sp_GetGuestById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(GuestEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", entity.id);
            dbparams.Add("F_Name", entity.F_Name);
            dbparams.Add("M_Name", entity.M_Name);
            dbparams.Add("L_Name", entity.L_Name);
            dbparams.Add("Email_id", entity.Email_id);
            dbparams.Add("Mobile_No", entity.Mobile_No);
            dbparams.Add("Type_of_Visit", entity.Type_of_Visit);
            dbparams.Add("Community", entity.Community);
            dbparams.Add("Floor", entity.Floor);
            dbparams.Add("Date_of_visit", entity.Date_of_visit);
            dbparams.Add("Time_of_visit", entity.Time_of_visit);
            dbparams.Add("Purpose_of_the_visit", entity.Purpose_of_the_visit);
            dbparams.Add("Parking_required", entity.Parking_required);
            dbparams.Add("Car_model_details", entity.Car_model_details);
            dbparams.Add("Plate_No", entity.Plate_No);
            dbparams.Add("Car_Registration_Card", entity.Car_Registration_Card);
            dbparams.Add("ID_No", entity.ID_No);
            dbparams.Add("Upload_ID_No", entity.Upload_ID_No);
            dbparams.Add("Delivery_company_Name", entity.Delivery_company_Name);
            dbparams.Add("Delivery_Staff_Name", entity.Delivery_Staff_Name);
            dbparams.Add("Staff_ID_Card_No", entity.Staff_ID_Card_No);
            dbparams.Add("Staff_ID_Card_Image", entity.Staff_ID_Card_Image);
            dbparams.Add("Type_of_Delivery", entity.Type_of_Delivery);
            dbparams.Add("Company_Name", entity.Company_Name);
            dbparams.Add("Number_of_Staff_to_Reach_the_Unit", entity.Number_of_Staff_to_Reach_the_Unit);
            dbparams.Add("Scope_of_Work", entity.Scope_of_Work);
            dbparams.Add("Materials_carrie_in", entity.Materials_carrie_in);
            dbparams.Add("Service_Provider_Staff_Name", entity.Service_Provider_Staff_Name);
            dbparams.Add("Staff_Mobile_Number", entity.Staff_Mobile_Number);
            dbparams.Add("Staff_ID_Card_image1", entity.Staff_ID_Card_image1);
            dbparams.Add("Staff_ID_Card_image2", entity.Staff_ID_Card_image2);
            dbparams.Add("Staff_ID_Card_image3", entity.Staff_ID_Card_image3);
            dbparams.Add("Staff_ID_Card_image4", entity.Staff_ID_Card_image4);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            //dbparams.Add("retVal", DbType.Int32, direction: ParameterDirection.Output);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateGuest", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
