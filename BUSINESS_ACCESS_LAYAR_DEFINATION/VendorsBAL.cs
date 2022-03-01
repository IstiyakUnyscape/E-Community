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
    public class VendorsBAL : IVendorsBAL
    {
        private readonly IVendorsDAL _VendorsDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public VendorsBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _VendorsDAL = new VendorsDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }
        public async Task<int> CreateVendors(VendorsModel entities)
        {
            if (entities.Tradelicense_Copy_File.Length > 0)
            {
                entities.Tradelicense_Copy = utility.FileUpload("UploadFile", entities.Tradelicense_Copy_File, webHostEnvironment);
            }
            if (entities.TRN_Certificate_File.Length > 0)
            {
                entities.TRN_Certificate = utility.FileUpload("UploadFile", entities.TRN_Certificate_File, webHostEnvironment);
            }
            if (entities.Owner_Passport_Copy_File.Length > 0)
            {
                entities.Owner_Passport_Copy = utility.FileUpload("UploadFile", entities.Owner_Passport_Copy_File, webHostEnvironment);
            }
            if (entities.Owner_Visa_Copy_File.Length > 0)
            {
                entities.Owner_Visa_Copy = utility.FileUpload("UploadFile", entities.Owner_Visa_Copy_File, webHostEnvironment);
            }
            if (entities.Third_Party_Liability_Insurance_Copy_File.Length > 0)
            {
                entities.Third_Party_Liability_Insurance_Copy = utility.FileUpload("UploadFile", entities.Third_Party_Liability_Insurance_Copy_File, webHostEnvironment);
            }
            if (entities.Workmen_Compensation_Insurance_Copy_File.Length > 0)
            {
                entities.Workmen_Compensation_Insurance_Copy = utility.FileUpload("UploadFile", entities.Workmen_Compensation_Insurance_Copy_File, webHostEnvironment);
            }
            if (entities.Additional_Insurance_File.Length > 0)
            {
                entities.Additional_Insurance = utility.FileUpload("UploadFile", entities.Additional_Insurance_File, webHostEnvironment);
            }
            if (entities.Additional_Certificate_File.Length > 0)
            {
                entities.Additional_Certificate = utility.FileUpload("UploadFile", entities.Additional_Certificate_File, webHostEnvironment);
            }
            if (entities.Profile_Image_File != null)
            {
                entities.Profile_Image = utility.FileUpload("UploadProfileImage", entities.Profile_Image_File, webHostEnvironment);
            }
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<VendorsEntities>(entities);
            return await _VendorsDAL.Create(data);
        }

        public async Task<int> DeleteVendors(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _VendorsDAL.Delete(Id);
        }

        public StaticPagedList<VendorsModel> GetAllVendors(SearchCompanyModel search)
        {
            var data = _VendorsDAL.GetAll(search);
            if (data == null) new StaticPagedList<VendorsModel>(new List<VendorsModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            var rdata = _mapper.Map<IEnumerable<VendorsModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<VendorsModel>(rdata, mData);
            return pagedList;
        }

        public VendorsModel GetVendorsById(string id)
        {
            var res = new VendorsEntities();

            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _VendorsDAL.GetById(Id);
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<VendorsModel>(res);
        }

        public async Task<int> UpdateVendors(VendorsModel entities)
        {
            entities.Id = _Iencryption.DecryptID(entities.Id);
            if (entities.Tradelicense_Copy_File != null)
            {
                entities.Tradelicense_Copy = utility.FileUpload("UploadFile", entities.Tradelicense_Copy_File, webHostEnvironment);
            }
            else
            {
                entities.Tradelicense_Copy = entities.Tradelicense_Copy;
            }
            if (entities.TRN_Certificate_File != null)
            {
                entities.TRN_Certificate = utility.FileUpload("UploadFile", entities.TRN_Certificate_File, webHostEnvironment);
            }
            else
            {
                entities.TRN_Certificate = entities.TRN_Certificate;
            }
            if (entities.Owner_Passport_Copy_File != null)
            {
                entities.Owner_Passport_Copy = utility.FileUpload("UploadFile", entities.Owner_Passport_Copy_File, webHostEnvironment);
            }
            else
            {
                entities.Owner_Passport_Copy = entities.Owner_Passport_Copy;
            }
            if (entities.Owner_Visa_Copy_File != null)
            {
                entities.Owner_Visa_Copy = utility.FileUpload("UploadFile", entities.Owner_Visa_Copy_File, webHostEnvironment);
            }
            else
            {
                entities.Owner_Visa_Copy = entities.Owner_Visa_Copy;
            }
            if (entities.Third_Party_Liability_Insurance_Copy_File != null)
            {
                entities.Third_Party_Liability_Insurance_Copy = utility.FileUpload("UploadFile", entities.Third_Party_Liability_Insurance_Copy_File, webHostEnvironment);
            }
            else
            {
                entities.Third_Party_Liability_Insurance_Copy = entities.Third_Party_Liability_Insurance_Copy;
            }
            if (entities.Workmen_Compensation_Insurance_Copy_File != null)
            {
                entities.Workmen_Compensation_Insurance_Copy = utility.FileUpload("UploadFile", entities.Workmen_Compensation_Insurance_Copy_File, webHostEnvironment);
            }
            else
            {
                entities.Workmen_Compensation_Insurance_Copy = entities.Third_Party_Liability_Insurance_Copy;
            }
            //obj.Workmen_Compensation_Insurance_ExpiryDate = entities.Workmen_Compensation_Insurance_ExpiryDate;
            if (entities.Additional_Insurance_File != null)
            {
                entities.Additional_Insurance = utility.FileUpload("UploadFile", entities.Additional_Insurance_File, webHostEnvironment);
            }
            else
            {
                entities.Additional_Insurance = entities.Additional_Insurance;
            }
            if (entities.Additional_Certificate_File != null)
            {
                entities.Additional_Certificate = utility.FileUpload("UploadFile", entities.Additional_Certificate_File, webHostEnvironment);
            }
            else
            {
                entities.Additional_Certificate = entities.Additional_Certificate;
            }
            if (entities.Profile_Image_File != null)
            {
                entities.Profile_Image = utility.FileUpload("UploadProfileImage", entities.Profile_Image_File, webHostEnvironment);
            }
            else
            {
                entities.Profile_Image = entities.Profile_Image;
            }

            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data = _mapper.Map<VendorsEntities>(entities);
            return await _VendorsDAL.Update(data);
        }
    }
}
