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
    public class EventBAL : IEventBAL
    {
        private readonly IEventDAL _EventDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public EventBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _EventDAL = new EventDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }
        public async Task<int> CreateEvent(EventModel entities)
        {
            if (entities.Upload_Document_File != null)
            {
                entities.UploadDocument = utility.FileUpload("UploadFile", entities.Upload_Document_File, webHostEnvironment);
            }
            entities .CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<EventEntities>(entities);
            return await _EventDAL.Create(data);
        }

        public async Task<int> DeleteEvent(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _EventDAL.Delete(Id);
        }

        public StaticPagedList<EventModel> GetAllEvent(SearchCompanyModel search)
        {
            if (!string.IsNullOrEmpty(search.UserId))
            {
                search.UserId = _Iencryption.EncryptID(search.UserId);
            }
            var Search = _mapper.Map<SearchCompanyEntities>(search);
            var data = _EventDAL.GetAll(Search);
            if (data == null) new StaticPagedList<EventModel>(new List<EventModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            var rdata = _mapper.Map<IEnumerable<EventModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<EventModel>(rdata, mData);
            return pagedList;
        }

        public EventModel GetEventById(string id)
        {
            var res = new EventEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _EventDAL.GetById(Id).Result;
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<EventModel>(res);
        }

        public async Task<int> UpdateEvent(EventModel entities)
        {
            entities.Id = _Iencryption.DecryptID(entities.Id);
            if (entities.Upload_Document_File != null)
            {
                utility.RemoveFile(entities.UploadDocument, "UploadFile", webHostEnvironment);
                entities.UploadDocument = utility.FileUpload("UploadFile", entities.Upload_Document_File, webHostEnvironment);
            }
            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data = _mapper.Map<EventEntities>(entities);
            return await _EventDAL.Update(data);
        }
    }
}
