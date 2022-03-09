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
    public class MilestoneBAL : IMilestoneBAL
    {
        private readonly IMilestoneDAL _MilestoneDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public MilestoneBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _MilestoneDAL = new MilestoneDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public StaticPagedList<MilestoneModel> GetAllMilestone(SearchCompanyModel search)
        {
            var data = _MilestoneDAL.GetAll(search);
            if (data == null) new StaticPagedList<MilestoneModel>(new List<MilestoneModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            var rdata = _mapper.Map<IEnumerable<MilestoneModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<MilestoneModel>(rdata, mData);
            return pagedList;
        }

        public MilestoneModel GetMilestoneById(string id)
        {
            var res = new MilestoneEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _MilestoneDAL.GetById(Id).Result;
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<MilestoneModel>(res);
        }

       
        public async Task<int> CreateMilestone(MilestoneModel entities)
        {
            if (entities.Upload_Document_File.Count > 0)
            {
                List<Documents_FileJson> objfile = new List<Documents_FileJson>();
                foreach (var file in entities.Upload_Document_File)
                {
                    Documents_FileJson filesJson = new Documents_FileJson();
                    filesJson.Upload_Document = utility.FileUpload("UploadFile", file, webHostEnvironment);
                    objfile.Add(filesJson);
                }
                entities.Upload_Document = JsonConvert.SerializeObject(objfile);
            }
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<MilestoneEntities>(entities);
            return await _MilestoneDAL.Create(data);
        }

        public async Task<int> UpdateMilestone(MilestoneModel entities)
        {
            entities.Id = _Iencryption.DecryptID(entities.Id);
            if (entities.Upload_Document_File.Count > 0)
            {
                List<Documents_FileJson> objfile = new List<Documents_FileJson>();
                foreach (var file in entities.Upload_Document_File)
                {
                    Documents_FileJson filesJson = new Documents_FileJson();
                    filesJson.Upload_Document = utility.FileUpload("UploadFile", file, webHostEnvironment);
                    objfile.Add(filesJson);
                }
                entities.Upload_Document = JsonConvert.SerializeObject(objfile);
            }
            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data = _mapper.Map<MilestoneEntities>(entities);
            return await _MilestoneDAL.Update(data);
        }

        public async Task<int> DeleteMilestone(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _MilestoneDAL.Delete(Id);
        }

        public IEnumerable<MilestoneModel> GetMilestoneByProjectId(int id)
        {
            var entities = _MilestoneDAL.GetAll().Where(x=>x.ProjectId==id).AsEnumerable();
            var data = _mapper.Map<IEnumerable<MilestoneModel>>(entities);
            return data;
        }

    }
}
