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
    public class RoleBAL : IRoleBAL
    {
        private readonly IRoleDAL _RoleDAL;
        private IWebHostEnvironment webHostEnvironment ;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public RoleBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _RoleDAL = new RoleDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public async Task<int> CreateRole(RoleModel entities)
        {
           
            var data = _mapper.Map<RoleEntities>(entities);
            return await _RoleDAL.Create(data);
           
        }

        public async Task<int> DeleteRole(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _RoleDAL.Delete(Id);
        }

        public StaticPagedList<RoleModel> GetAllRole(SearchCompanyModel search)
        {
              var data = _RoleDAL.GetAll(search);
                if(data==null) new StaticPagedList<RoleModel>(new List<RoleModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.id = _Iencryption.EncryptID(obj.id);
            }
                var rdata= _mapper.Map<IEnumerable<RoleModel>>(data.ToArray());
                var mData = data.GetMetaData();
                var pagedList = new StaticPagedList<RoleModel>(rdata, mData);
                return pagedList;

           
        }

        public RoleModel GetRoleById(string id)
        {
            var res = new RoleEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _RoleDAL.GetById(Id).Result;
                res.id= _Iencryption.EncryptID(res.id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<RoleModel>(res);
        }

        public async Task<int> UpdateRole(RoleModel entities)
        {
            entities.Id= _Iencryption.DecryptID(entities.Id);
            
            var data= _mapper.Map<RoleEntities>(entities);
            return await _RoleDAL.Update(data);

        }

        public IEnumerable<RoleEntities> GetAllRole()
        {
            var data= _RoleDAL.GetAll();
            foreach (var obj in data)
            {
                obj.id = _Iencryption.EncryptID(obj.id);
            }
            return data;
        }

    }
}
