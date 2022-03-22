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
    public class BulletinDAL : IBulletinDAL
    {
        private readonly IDapper _dapper;
        public BulletinDAL()
        {
            _dapper = new Dapperr();
        }
        public async Task<int> Create(BulletinEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Title", entity.Title);
            dbparams.Add("Description", entity.Description);
            dbparams.Add("Upload_Pictures", entity.Upload_Pictures);
            dbparams.Add("Attach_Documents", entity.Attach_Documents);
            dbparams.Add("Mobile_No", entity.Mobile_No);
            dbparams.Add("EmailId", entity.EmailId);
            dbparams.Add("Price", entity.Price);
            dbparams.Add("Availability_To_Contact", entity.Availability_To_Contact);
            dbparams.Add("Created_at", DateTime.Now);
            dbparams.Add("CreatedBy", entity.CreatedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("Isdeleted", false);
            var result = await Task.FromResult(_dapper.Insert<int>("sp_InsertBulletin", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Update<int>("sp_DeleteBulletin", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public IPagedList<BulletinViewEntities> GetAll(SearchCompanyEntities search)
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("Id", id, DbType.Int32);
            IQueryable<BulletinViewEntities> result = _dapper.GetAll<BulletinViewEntities>("sp_GetBulletin", dbparams, commandType: CommandType.StoredProcedure).Distinct().AsQueryable();
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
            IOrderedQueryable<BulletinViewEntities> OrderedQuery = null;

            if (!string.IsNullOrEmpty(search.SortColumn))
            {
                Type type = typeof(BulletinViewEntities);
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

        public async Task<BulletinEntities> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            var res = await Task.FromResult(_dapper.Get<BulletinEntities>("sp_GetBulletinById", dbparams, commandType: CommandType.StoredProcedure));
            return res;
        }

        public async Task<int> Update(BulletinEntities entity)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", Convert.ToInt32(entity.Id));
            dbparams.Add("Title", entity.Title);
            dbparams.Add("Description", entity.Description);
            dbparams.Add("Upload_Pictures", entity.Upload_Pictures);
            dbparams.Add("Attach_Documents", entity.Attach_Documents);
            dbparams.Add("Mobile_No", entity.Mobile_No);
            dbparams.Add("EmailId", entity.EmailId);
            dbparams.Add("Price", entity.Price);
            dbparams.Add("Availability_To_Contact", entity.Availability_To_Contact);
            dbparams.Add("Modified_at", DateTime.Now);
            dbparams.Add("ModifiedBy", entity.ModifiedBy);
            dbparams.Add("Isactive", true);
            dbparams.Add("StatusTypeDetailID", entity.StatusTypeDetailID);
            dbparams.Add("ApprovedDate", entity.ApprovedDate);
            dbparams.Add("Remarks", entity.Remarks);
            dbparams.Add("IsShowAdmin", entity.IsShowAdmin);
            var result = await Task.FromResult(_dapper.Update<int>("sp_UpdateBulletin", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
