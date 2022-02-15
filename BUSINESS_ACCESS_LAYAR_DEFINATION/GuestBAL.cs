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
    public class GuestBAL: IGuestBAL
    {
        private readonly IGuestDAL _GuestDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public GuestBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _GuestDAL = new GuestDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public StaticPagedList<GuestModel> GetAllGuest(SearchCompanyModel search)
        {
            var data = _GuestDAL.GetAll(search);
            if (data == null) new StaticPagedList<GuestModel>(new List<GuestModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.id = _Iencryption.EncryptID(obj.id);
            }
            var rdata = _mapper.Map<IEnumerable<GuestModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<GuestModel>(rdata, mData);
            return pagedList;
        }

        public GuestModel GetGuestById(string id)
        {
            var res = new GuestEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _GuestDAL.GetById(Id).Result;
                res.id = _Iencryption.EncryptID(res.id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<GuestModel>(res);
        }

        public async Task<int> CreateGuest(GuestModel entities)
        {
            if (entities.Upload_ID_No_File != null)
            {
                entities.Upload_ID_No = utility.FileUpload("UploadFile", entities.Upload_ID_No_File, webHostEnvironment);
            }
            if (entities.Car_Registration_Card_File != null)
            {
                entities.Car_Registration_Card = utility.FileUpload("UploadFile", entities.Car_Registration_Card_File, webHostEnvironment);
            }
            if (entities.Staff_ID_Card_Image_File != null)
            {
                entities.Staff_ID_Card_Image = utility.FileUpload("UploadFile", entities.Staff_ID_Card_Image_File, webHostEnvironment);
            }

            if (entities.Staff_ID_Card_image1_File != null)
            {
                entities.Staff_ID_Card_image1 = utility.FileUpload("UploadFile", entities.Staff_ID_Card_image1_File, webHostEnvironment);
            }

            if (entities.Staff_ID_Card_image2_File != null)
            {
                entities.Staff_ID_Card_image2 = utility.FileUpload("UploadFile", entities.Staff_ID_Card_image2_File, webHostEnvironment);
            }
            if (entities.Staff_ID_Card_image3_File != null)
            {
                entities.Staff_ID_Card_image3 = utility.FileUpload("UploadFile", entities.Staff_ID_Card_image3_File, webHostEnvironment);
            }
            if (entities.Staff_ID_Card_image4_File != null)
            {
                entities.Staff_ID_Card_image4 = utility.FileUpload("UploadFile", entities.Staff_ID_Card_image4_File, webHostEnvironment);
            }
            var data = _mapper.Map<GuestEntities>(entities);
            return await _GuestDAL.Create(data);
        }

        public async Task<int> UpdateGuest(GuestModel entities)
        {
            entities.id = _Iencryption.DecryptID(entities.id);
            if (entities.Upload_ID_No_File != null)
            {
                utility.RemoveFile(entities.Upload_ID_No, "UploadFile", webHostEnvironment);
                entities.Upload_ID_No = utility.FileUpload("UploadFile", entities.Upload_ID_No_File, webHostEnvironment);
            }
            else
            {
                entities.Upload_ID_No = entities.Upload_ID_No;
            }
            if (entities.Car_Registration_Card_File != null)
            {
                utility.RemoveFile(entities.Car_Registration_Card, "UploadFile", webHostEnvironment);
                entities.Car_Registration_Card = utility.FileUpload("UploadFile", entities.Car_Registration_Card_File, webHostEnvironment);
            }
            else
            {
                entities.Car_Registration_Card = entities.Car_Registration_Card;
            }
            if (entities.Staff_ID_Card_Image_File != null)
            {
                utility.RemoveFile(entities.Staff_ID_Card_Image, "UploadFile", webHostEnvironment);
                entities.Staff_ID_Card_Image = utility.FileUpload("UploadFile", entities.Staff_ID_Card_Image_File, webHostEnvironment);
            }
            else
            {
                entities.Staff_ID_Card_Image = entities.Staff_ID_Card_Image;
            }
            if (entities.Staff_ID_Card_image1_File != null)
            {
                utility.RemoveFile(entities.Staff_ID_Card_image1, "UploadFile", webHostEnvironment);
                entities.Staff_ID_Card_image1 = utility.FileUpload("UploadFile", entities.Staff_ID_Card_image1_File, webHostEnvironment);
            }
            else
            {
                entities.Staff_ID_Card_image1 = entities.Staff_ID_Card_image1;
            }
            if (entities.Staff_ID_Card_image2_File != null)
            {
                utility.RemoveFile(entities.Staff_ID_Card_image2, "UploadFile", webHostEnvironment);
                entities.Staff_ID_Card_image2 = utility.FileUpload("UploadFile", entities.Staff_ID_Card_image2_File, webHostEnvironment);
            }
            else
            {
                entities.Staff_ID_Card_image2 = entities.Staff_ID_Card_image2;
            }
            if (entities.Staff_ID_Card_image3_File != null)
            {
                utility.RemoveFile(entities.Staff_ID_Card_image3, "UploadFile", webHostEnvironment);
                entities.Staff_ID_Card_image3 = utility.FileUpload("UploadFile", entities.Staff_ID_Card_image3_File, webHostEnvironment);
            }
            else
            {
                entities.Staff_ID_Card_image3 = entities.Staff_ID_Card_image3;
            }
            if (entities.Staff_ID_Card_image4_File != null)
            {
                utility.RemoveFile(entities.Staff_ID_Card_image4, "UploadFile", webHostEnvironment);
                entities.Staff_ID_Card_image4 = utility.FileUpload("UploadFile", entities.Staff_ID_Card_image4_File, webHostEnvironment);
            }
            else
            {
                entities.Staff_ID_Card_image4= entities.Staff_ID_Card_image4;
            }
            var data = _mapper.Map<GuestEntities>(entities);
            return await _GuestDAL.Update(data);
        }

        public async Task<int> DeleteGuest(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _GuestDAL.Delete(Id);
        }
    }
}
