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
    public class NoticesBAL: INoticesBAL
    {
        private readonly INoticesDAL _NoticesDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public NoticesBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _NoticesDAL = new NoticesDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public StaticPagedList<NoticesViewModel> GetAllNotices(SearchCompanyModel search)
        {

            if (!string.IsNullOrEmpty(search.UserId))
            {
                search.UserId = _Iencryption.EncryptID(search.UserId);
            }
            var Search = _mapper.Map<SearchCompanyEntities>(search);
            var data = _NoticesDAL.GetAll(Search);
            var currentDate = DateTime.Now;
            
            if (data == null) new StaticPagedList<NoticesViewModel>(new List<NoticesViewModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
                if(obj.StartDate>currentDate)
                {
                    obj.Status = "Upcomming";
                }
                else if(obj.StartDate<=currentDate && obj.EndDate >= currentDate)
                    {
                    obj.Status = "Active";
                  }
                else
                {
                    obj.Status = "Expaired";
                }
            }
            var rdata = _mapper.Map<IEnumerable<NoticesViewModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<NoticesViewModel>(rdata, mData);
            return pagedList;
        }

        public NoticesModel GetNoticesById(string id)
        {
            var res = new NoticesEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _NoticesDAL.GetById(Id).Result;
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<NoticesModel>(res);
        }

        public async Task<int> CreateNotices(NoticesModel entities)
        {
            if (entities.Upload_Document_File != null)
            {
                entities.UploadDocument = utility.FileUpload("UploadFile", entities.Upload_Document_File, webHostEnvironment);
            }
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<NoticesEntities>(entities);
            return await _NoticesDAL.Create(data);
        }

        public async Task<int> UpdateNotices(NoticesModel entities)
        {
            entities.Id = _Iencryption.DecryptID(entities.Id);
            if (entities.Upload_Document_File != null)
            {
                utility.RemoveFile(entities.UploadDocument, "UploadFile", webHostEnvironment);
                entities.UploadDocument = utility.FileUpload("UploadFile", entities.Upload_Document_File, webHostEnvironment);
            }
            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data = _mapper.Map<NoticesEntities>(entities);
            return await _NoticesDAL.Update(data);
        }

        public async Task<int> DeleteNotices(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _NoticesDAL.Delete(Id);
        }
    }
}
