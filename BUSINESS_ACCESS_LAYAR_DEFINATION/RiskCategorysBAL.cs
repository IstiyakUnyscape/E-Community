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
    public class RiskCategorysBAL : IRiskCategorysBAL
    {
        private readonly IRiskCategorysDAL _RiskCategorysDAL;
        private IWebHostEnvironment webHostEnvironment ;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public RiskCategorysBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _RiskCategorysDAL = new RiskCategorysDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public async Task<int> CreateRiskCategorys(RiskCategorysModel entities)
        {
            entities.CreatedBy = _Iencryption.DecryptID(entities.CreatedBy);
            var data = _mapper.Map<RiskCategorysEntities>(entities);
           
            return await _RiskCategorysDAL.Create(data);
           
        }

        public async Task<int> DeleteRiskCategorys(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _RiskCategorysDAL.Delete(Id);
        }

        public StaticPagedList<RiskCategorysModel> GetAllRiskCategorys(SearchCompanyModel search)
        {
              var data = _RiskCategorysDAL.GetAll(search);
                if(data==null) new StaticPagedList<RiskCategorysModel>(new List<RiskCategorysModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.id = _Iencryption.EncryptID(obj.id);
            }
                var rdata= _mapper.Map<IEnumerable<RiskCategorysModel>>(data.ToArray());
                var mData = data.GetMetaData();
                var pagedList = new StaticPagedList<RiskCategorysModel>(rdata, mData);
                return pagedList;           
        }

        public RiskCategorysModel GetRiskCategorysById(string id)
        {
            var res = new RiskCategorysEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _RiskCategorysDAL.GetById(Id).Result;
                res.id= _Iencryption.EncryptID(res.id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<RiskCategorysModel>(res);
        }

        public async Task<int> UpdateRiskCategorys(RiskCategorysModel entities)
        {
            entities.Id= _Iencryption.DecryptID(entities.Id);
            entities.ModifiedBy = _Iencryption.DecryptID(entities.ModifiedBy);
            var data= _mapper.Map<RiskCategorysEntities>(entities);
            return await _RiskCategorysDAL.Update(data);

        }

        public IEnumerable<RiskCategorysEntities> GetAllRiskCategorys()
        {
            var data= _RiskCategorysDAL.GetAll();
            foreach (var obj in data)
            {
                obj.id = _Iencryption.EncryptID(obj.id);
            }
            return data;
        }

    }
}
