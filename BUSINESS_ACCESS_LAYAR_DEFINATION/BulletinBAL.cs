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
    public class BulletinBAL : IBulletinBAL
    {
        private readonly IBulletinDAL _BulletinDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public BulletinBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _BulletinDAL = new BulletinDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }
        public async Task<int> CreateBulletin(BulletinModel entities)
        {
            if (entities.Upload_Pictures_File!=null)
            {
                List<Upload_Pictures_FileJson> objfile = new List<Upload_Pictures_FileJson>();
                foreach (var file in entities.Upload_Pictures_File)
                {
                    Upload_Pictures_FileJson filesJson = new Upload_Pictures_FileJson();
                    filesJson.Upload_Pictures = utility.FileUpload("UploadFile", file, webHostEnvironment);
                    objfile.Add(filesJson);
                }
                entities.Upload_Pictures = JsonConvert.SerializeObject(objfile);
            }
           
             if (entities.Attach_Documents_Files!=null)
             {
                List<Attach_Documents_FileJson> objfile = new List<Attach_Documents_FileJson>();
                foreach (var file in entities.Attach_Documents_Files)
                {
                    Attach_Documents_FileJson filesJson = new Attach_Documents_FileJson();
                    filesJson.Attach_Documents = utility.FileUpload("UploadFile", file, webHostEnvironment);
                    objfile.Add(filesJson);
                }
                entities.Attach_Documents = JsonConvert.SerializeObject(objfile);
            }
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<BulletinEntities>(entities);
            return await _BulletinDAL.Create(data);
        }

        public async Task<int> DeleteBulletin(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _BulletinDAL.Delete(Id);
        }

        public StaticPagedList<BulletinModel> GetAllBulletin(SearchCompanyModel search)
        {
            var data = _BulletinDAL.GetAll(search);
            if (data == null) new StaticPagedList<BulletinModel>(new List<BulletinModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            var rdata = _mapper.Map<IEnumerable<BulletinModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<BulletinModel>(rdata, mData);
            return pagedList;
        }

        public BulletinModel GetBulletinById(string id)
        {
            var res = new BulletinEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _BulletinDAL.GetById(Id).Result;
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<BulletinModel>(res);
        }

        public async Task<int> UpdateBulletin(BulletinModel entities)
        {
            entities.Id = _Iencryption.DecryptID(entities.Id);
            if (entities.Upload_Pictures_File!=null)
            {
                List<Upload_Pictures_FileJson> objfile = new List<Upload_Pictures_FileJson>();
                foreach (var file in entities.Upload_Pictures_File)
                {
                    Upload_Pictures_FileJson filesJson = new Upload_Pictures_FileJson();
                    filesJson.Upload_Pictures = utility.FileUpload("UploadFile", file, webHostEnvironment);
                    objfile.Add(filesJson);
                }
                entities.Upload_Pictures = JsonConvert.SerializeObject(objfile);
            }
            if (entities.Attach_Documents_Files != null)
            {
                List<Attach_Documents_FileJson> objfile = new List<Attach_Documents_FileJson>();
                foreach (var file in entities.Attach_Documents_Files)
                {
                    Attach_Documents_FileJson filesJson = new Attach_Documents_FileJson();
                    filesJson.Attach_Documents = utility.FileUpload("UploadFile", file, webHostEnvironment);
                    objfile.Add(filesJson);
                }
                entities.Attach_Documents = JsonConvert.SerializeObject(objfile);
            }
            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data = _mapper.Map<BulletinEntities>(entities);
            return await _BulletinDAL.Update(data);
        }
    }
}
