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
        public async Task<string> CreateStaff(StaffModel entities)
        {           
            if (entities.ID_upload_Picture_File != null)
            {
                entities.ID_upload_Picture = utility.FileUpload("UploadFile", entities.ID_upload_Picture_File, webHostEnvironment);
            }
            if (entities.Profile_Image_File != null)
            {
                entities.Profile_Image = utility.FileUpload("UploadProfileImage", entities.Profile_Image_File, webHostEnvironment);
            }
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<StaffEntities>(entities);
            var res = await _StaffDAL.Create(data);
            if (res == -1)
            {
                return res.ToString();
            }
            else
            {
                return _Iencryption.EncryptID(res.ToString());
            }
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
                res = _StaffDAL.GetById(Id);
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
            if (entities.ID_upload_Picture_File != null)
            {
                entities.ID_upload_Picture = utility.FileUpload("UploadFile", entities.ID_upload_Picture_File, webHostEnvironment);
            }
            else
            {
                entities.ID_upload_Picture = entities.ID_upload_Picture;
            }
            if (entities.Profile_Image_File != null)
            {
                entities.Profile_Image = utility.FileUpload("UploadProfileImage", entities.Profile_Image_File, webHostEnvironment);
            }
            else
            {
                entities.Profile_Image = entities.Profile_Image;
            }
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy); 
            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data = _mapper.Map<StaffEntities>(entities);

            return await _StaffDAL.Update(data);
        }
    }
}
