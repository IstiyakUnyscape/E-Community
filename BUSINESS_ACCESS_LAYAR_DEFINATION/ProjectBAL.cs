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
    public class ProjectBAL : IProjectBAL
    {
        private readonly IProjectDAL _ProjectDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public ProjectBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _ProjectDAL = new ProjectDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }
        public async Task<int> CreateProject(ProjectModel entities)
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
            var data = _mapper.Map<ProjectEntities>(entities);
            return await _ProjectDAL.Create(data);
        }

        public async Task<int> DeleteProject(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _ProjectDAL.Delete(Id);
        }

        public StaticPagedList<ProjectModel> GetAllProject(SearchCompanyModel search)
        {
            if (!string.IsNullOrEmpty(search.UserId))
            {
                search.UserId = _Iencryption.EncryptID(search.UserId);
            }
            var Search = _mapper.Map<SearchCompanyEntities>(search);
            var data = _ProjectDAL.GetAll(Search);
            if (data == null) new StaticPagedList<ProjectModel>(new List<ProjectModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            var rdata = _mapper.Map<IEnumerable<ProjectModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<ProjectModel>(rdata, mData);
            return pagedList;
        }

        public ProjectModel GetProjectById(string id)
        {
            var res = new ProjectEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _ProjectDAL.GetById(Id).Result;
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<ProjectModel>(res);
        }

        public async Task<int> UpdateProject(ProjectModel entities)
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
            var data = _mapper.Map<ProjectEntities>(entities);
            return await _ProjectDAL.Update(data);
        }

        public StaticPagedList<ProjectViewModel> GetAllProjectView(SearchCompanyModel search)
        {
            if(!string.IsNullOrEmpty(search.UserId))
            {
                search.UserId = _Iencryption.EncryptID(search.UserId);
            }
            var Search = _mapper.Map<SearchCompanyEntities>(search);
            var data = _ProjectDAL.GetAllProject(Search);
            if (data == null) new StaticPagedList<ProjectViewModel>(new List<ProjectViewModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
                
            }
            var rdata = _mapper.Map<IEnumerable<ProjectViewModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<ProjectViewModel>(rdata, mData);
            return pagedList;
        }
    }
}
