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
    public class RiskRegistryBAL : IRiskRegistryBAL
    {
        private readonly IRiskRegistryDAL _RiskRegistryDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public RiskRegistryBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _RiskRegistryDAL = new RiskRegistryDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }
        public async Task<int> CreateRiskRegistry(RiskRegistryModel entities)
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
            var data = _mapper.Map<RiskRegistryEntities>(entities);
            return await _RiskRegistryDAL.Create(data);
        }

        public async Task<int> DeleteRiskRegistry(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _RiskRegistryDAL.Delete(Id);
        }

        public StaticPagedList<RiskRegistryModel> GetAllRiskRegistry(SearchCompanyModel search)
        {
            var data = _RiskRegistryDAL.GetAll(search);
            if (data == null) new StaticPagedList<RiskRegistryModel>(new List<RiskRegistryModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.Id = _Iencryption.EncryptID(obj.Id);
            }
            var rdata = _mapper.Map<IEnumerable<RiskRegistryModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<RiskRegistryModel>(rdata, mData);
            return pagedList;
        }

        public RiskRegistryModel GetRiskRegistryById(string id)
        {
            var res = new RiskRegistryEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _RiskRegistryDAL.GetById(Id).Result;
                res.Id = _Iencryption.EncryptID(res.Id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<RiskRegistryModel>(res);
        }

        public async Task<int> UpdateRiskRegistry(RiskRegistryModel entities)
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
            var data = _mapper.Map<RiskRegistryEntities>(entities);
            return await _RiskRegistryDAL.Update(data);
        }
    }
}
