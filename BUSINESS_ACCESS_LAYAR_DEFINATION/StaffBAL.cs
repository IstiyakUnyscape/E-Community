using AutoMapper;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using COMMON_SERVICES_DEFINATION;
using COMMON_SERVICES_INTERFACE;
using CustomModel;
using DATA_ACCESS_LAYAR_DEFINATION;
using DATA_ACCESS_LAYAR_INTERFACE;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_DEFINATION
{
    public class StaffBAL : IStaffBAL
    {
        private readonly IStaffDAL _StaffDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public StaffBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _StaffDAL = new StaffDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }
        public async Task<int> CreateStaff(StaffModel entities)
        {
            //StaffEntities obj = new StaffEntities();
            //obj.F_Name = entities.F_Name;
            //obj.M_Name = entities.M_Name;
            //obj.L_Name = entities.L_Name;
            //obj.Email_Id = entities.Email_Id;
            //obj.Mobile_No = entities.Mobile_No;
            //obj.Designation = entities.Designation;
            //obj.Reporting_To = entities.Reporting_To;
            //obj.Address = entities.Address;
            //obj.Country = entities.Country;
            //obj.State = entities.State;
            //obj.City = entities.City;
            //obj.Postal_Code = entities.Postal_Code;
            //obj.Community = entities.Community;
            //obj.Identification_CardNo = entities.Id;
            //obj.ID_expiry_Date = entities.ID_expiry_Date;
            if (entities.ID_upload_Picture_File.Length > 0)
            {
                entities.ID_upload_Picture = utility.FileUpload("UploadFile", entities.ID_upload_Picture_File, webHostEnvironment);
            }
            //entities.Created_at = DateTime.Now;
            //entities.Isactive = true;
            //entities.Isdeleted = false;
            var data = _mapper.Map<StaffEntities>(entities);
            return await _StaffDAL.Create(data);
        }

        public async Task<int> DeleteStaff(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _StaffDAL.Delete(Id);
        }

        public StaticPagedList<StaffModel> GetAllStaff(SearchStaffModel search)
        {
            var data = _StaffDAL.GetAll(search);
            if (data == null) new StaticPagedList<StaffModel>(new List<StaffModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            var rdata = _mapper.Map<IEnumerable<StaffModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<StaffModel>(rdata, mData);
            return pagedList;
        }

        public StaffModel GetStaffById(string id)
        {
            var res = new StaffEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));//(_Iencryption.DecryptID(id));
            try
            {
                res =  _StaffDAL.GetById(Id);
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<StaffModel>(res);
        }

        public async Task<int> UpdateStaff(StaffModel entities)
        {
            entities.Id = _Iencryption.DecryptID(entities.Id);
            if (entities.ID_upload_Picture_File!= null)
            {
                entities.ID_upload_Picture = utility.FileUpload("UploadFile", entities.ID_upload_Picture_File, webHostEnvironment);
            }
            else
            {
                entities.ID_upload_Picture = entities.ID_upload_Picture;
            }
            //entities.Modified_at = DateTime.Now;
            //entities.Isactive = true;
            var data = _mapper.Map<StaffEntities>(entities);
          
            return await _StaffDAL.Update(data);
        }
    }
}
