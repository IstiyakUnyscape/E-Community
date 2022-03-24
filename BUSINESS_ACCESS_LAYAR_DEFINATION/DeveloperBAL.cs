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
    public class DeveloperBAL : IDeveloperBAL
    {
        private readonly IDeveloperDAL _DeveloperDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public DeveloperBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _DeveloperDAL = new DeveloperDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public StaticPagedList<DeveloperViewModel> GetAllDeveloper(SearchCompanyModel search)
        {
            if (!string.IsNullOrEmpty(search.UserId))
            {
                search.UserId = _Iencryption.EncryptID(search.UserId);
            }
            var Search = _mapper.Map<SearchCompanyEntities>(search);
            var data = _DeveloperDAL.GetAll(Search);
            if (data == null) new StaticPagedList<DeveloperViewModel>(new List<DeveloperViewModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            var rdata = _mapper.Map<IEnumerable<DeveloperViewModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<DeveloperViewModel>(rdata, mData);
            return pagedList;
        }

        public DeveloperModel GetDeveloperById(string id)
        {
            var res = new DeveloperEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _DeveloperDAL.GetById(Id).Result;
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<DeveloperModel>(res);
        }

        public async Task<int> CreateDeveloper(DeveloperModel entities)
        {
            if (entities.License_Document_File!=null)
            {
                entities.License_Document = utility.FileUpload("UploadFile", entities.License_Document_File, webHostEnvironment);
            }
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<DeveloperEntities>(entities);
            return await _DeveloperDAL.Create(data);
        }

        public async Task<int> UpdateDeveloper(DeveloperModel entities)
        {
            entities.Id = _Iencryption.DecryptID(entities.Id);
            if (entities.License_Document_File != null)
            {
                entities.License_Document = utility.FileUpload("UploadFile", entities.License_Document_File, webHostEnvironment);
            }
            else
            {
                entities.License_Document = entities.License_Document;
            }
            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data = _mapper.Map<DeveloperEntities>(entities);
            return await _DeveloperDAL.Update(data);
        }

        public async Task<int> DeleteDeveloper(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _DeveloperDAL.Delete(Id);
        }
    }
}
