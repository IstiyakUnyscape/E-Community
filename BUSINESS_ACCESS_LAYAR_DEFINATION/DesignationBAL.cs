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
    public class DesignationBAL : IDesignationBAL
    {
        private readonly IDesignationDAL _DesignationDAL;
        private IWebHostEnvironment webHostEnvironment ;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public DesignationBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _DesignationDAL = new DesignationDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public async Task<int> CreateDesignation(DesignationModel entities)
        {
           
            var data = _mapper.Map<DesignationEntities>(entities);
            return await _DesignationDAL.Create(data);
           
        }

        public async Task<int> DeleteDesignation(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _DesignationDAL.Delete(Id);
        }

        public StaticPagedList<DesignationModel> GetAllDesignation(SearchCompanyModel search)
        {
              var data = _DesignationDAL.GetAll(search);
                if(data==null) new StaticPagedList<DesignationModel>(new List<DesignationModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.id = _Iencryption.EncryptID(obj.id);
            }
                var rdata= _mapper.Map<IEnumerable<DesignationModel>>(data.ToArray());
                var mData = data.GetMetaData();
                var pagedList = new StaticPagedList<DesignationModel>(rdata, mData);
                return pagedList;

           
        }

        public DesignationModel GetDesignationById(string id)
        {
            var res = new DesignationEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _DesignationDAL.GetById(Id).Result;
                res.id= _Iencryption.EncryptID(res.id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<DesignationModel>(res);
        }

        public async Task<int> UpdateDesignation(DesignationModel entities)
        {
            entities.Id= _Iencryption.DecryptID(entities.Id);
            
            var data= _mapper.Map<DesignationEntities>(entities);
            return await _DesignationDAL.Update(data);

        }

        public IEnumerable<DesignationEntities> GetAllDesignation()
        {
            var data= _DesignationDAL.GetAll();
            foreach (var obj in data)
            {
                obj.id = _Iencryption.EncryptID(obj.id);
            }
            return data;
        }

    }
}
