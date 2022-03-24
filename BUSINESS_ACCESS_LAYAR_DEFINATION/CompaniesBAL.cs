using AutoMapper;
using BUSINESS_ACCESS_LAYAR_INTERFACE;
using BUSINESS_ENTITIES;
using COMMON_SERVICES_DEFINATION;
using COMMON_SERVICES_INTERFACE;
using CustomModel;
using DATA_ACCESS_LAYAR_DEFINATION;
using DATA_ACCESS_LAYAR_INTERFACE;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_DEFINATION
{
    public class CompaniesBAL : ICompaniesBAL
    {
        private readonly ICompaniesDAL _CompaniesDAL;
        private IWebHostEnvironment webHostEnvironment ;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public CompaniesBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _CompaniesDAL = new CompaniesDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public async Task<int> CreateCompany(CompanyModel entities)
        {
            if (entities.Tradelicense_Copy_File != null)
            {
                entities.Tradelicense_Copy = utility.FileUpload("UploadFile", entities.Tradelicense_Copy_File, webHostEnvironment);
            }
            if (entities.Insurance_File != null)
            {
                entities.Insurance = utility.FileUpload("UploadFile", entities.Insurance_File, webHostEnvironment);
            }
            if (entities.TRN_Certificate_File != null)
            {
                entities.TRN_Certificate = utility.FileUpload("UploadFile", entities.TRN_Certificate_File, webHostEnvironment);
            }

            if (entities.Owner_Passport_Copy_File != null)
            {
                entities.Owner_Passport_Copy = utility.FileUpload("UploadFile", entities.Owner_Passport_Copy_File, webHostEnvironment);
            }

            if (entities.Owner_Visa_Copy_File != null)
            {
                entities.Owner_Visa_Copy = utility.FileUpload("UploadFile", entities.Owner_Visa_Copy_File, webHostEnvironment);
            }
            if (entities.Profile_Image_File != null)
            {
                entities.Profile_Image = utility.FileUpload("UploadProfileImage", entities.Profile_Image_File, webHostEnvironment);
            }
            if (entities.Additional_CertificatesFiles!=null)
            {
                List<AdditionalCertificateJson> Jsondata = new List<AdditionalCertificateJson>();
                List<FilesDynamic> addtionalFilesDynamics = utility.GetListModel(entities.Additional_CertificatesFiles,entities.Additional_Certificate_Title, entities.Additional_Certificate_ExpiryDate);
                foreach (var additionObj in addtionalFilesDynamics)
                {
                    AdditionalCertificateJson Jsondataobj = new AdditionalCertificateJson();
                    var file = additionObj.Files;
                    if (file != null)
                    {
                        Jsondataobj.Additional_Certificates = utility.FileUpload("UploadFile", file, webHostEnvironment);
                    }

                    Jsondataobj.Additional_Certificate_ExpiryDate = additionObj.ExpiryDate;
                    Jsondataobj.Additional_Certificate_Title = additionObj.Title;

                    Jsondata.Add(Jsondataobj);

                }
                entities.Additional_Certificates = JsonConvert.SerializeObject(Jsondata);
            }
            
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<CompanyEntities>(entities);
            return await _CompaniesDAL.Create(data);

        }

        public async Task<int> DeleteCompany(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _CompaniesDAL.Delete(Id);
        }

        public StaticPagedList<CompanyModel> GetAllCompany(SearchCompanyModel search)
        {
              var data =  _CompaniesDAL.GetAll(search);
                if(data==null) new StaticPagedList<CompanyModel>(new List<CompanyModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
                var rdata= _mapper.Map<IEnumerable<CompanyModel>>(data.ToArray());
                var mData = data.GetMetaData();
                var pagedList = new StaticPagedList<CompanyModel>(rdata, mData);
                return pagedList;

           
        }

        public CompanyModel GetCompanyById(string id)
        {
            var res = new CompanyEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res =  _CompaniesDAL.GetById(Id).Result;
                res.Id= _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<CompanyModel>(res);
        }

        public async Task<int> UpdateCompany(CompanyModel entities)
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
            if (entities.Insurance_File != null)
            {
                entities.Insurance = utility.FileUpload("UploadFile", entities.Insurance_File, webHostEnvironment);
            }
            else
            {
                entities.Insurance = entities.Insurance;
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
            if (entities.Profile_Image_File != null)
            {
                entities.Profile_Image = utility.FileUpload("UploadProfileImage", entities.Profile_Image_File, webHostEnvironment);
            }
            else
            {
                entities.Profile_Image = entities.Profile_Image;
            }
            if (entities.Additional_CertificatesFiles!=null)
            {
                List<AdditionalCertificateJson> Jsondata = new List<AdditionalCertificateJson>();
                List<FilesDynamic> addtionalFilesDynamics = utility.GetListModel(entities.Additional_CertificatesFiles, entities.Additional_Certificate_Title, entities.Additional_Certificate_ExpiryDate);
                foreach (var additionObj in addtionalFilesDynamics)
                {
                    AdditionalCertificateJson Jsondataobj = new AdditionalCertificateJson();
                    var file = additionObj.Files;
                    if (file != null)
                    {
                        Jsondataobj.Additional_Certificates = utility.FileUpload("UploadFile", file, webHostEnvironment);
                    }

                    Jsondataobj.Additional_Certificate_ExpiryDate = additionObj.ExpiryDate;
                    Jsondataobj.Additional_Certificate_Title = additionObj.Title;

                    Jsondata.Add(Jsondataobj);

                }
                entities.Additional_Certificates = JsonConvert.SerializeObject(Jsondata);
            }
            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data = _mapper.Map<CompanyEntities>(entities);
            return await _CompaniesDAL.Update(data);

        }

        public IEnumerable<CompanyEntities> GetAllCompany()
        {
            var data= _CompaniesDAL.GetAll();
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            return data;
        }

    }
}
