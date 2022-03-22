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
    public class MenuBAL : IMenuBAL
    {
        private readonly IMenuDAL _MenuDAL;
        private IWebHostEnvironment webHostEnvironment;
        private readonly Utility utility;
        private readonly Iencryption _Iencryption;
        private readonly IMapper _mapper;
        public MenuBAL(IWebHostEnvironment _host, IMapper mapper)
        {
            _mapper = mapper;
            _MenuDAL = new MenuDAL();
            utility = new Utility();
            _Iencryption = new EncryptionDefination();
            webHostEnvironment = _host;
        }

        public StaticPagedList<MenuModel> GetAllMenu(SearchCompanyModel search)
        {
            var data = _MenuDAL.GetAll(search);
            if (data == null) new StaticPagedList<MenuModel>(new List<MenuModel>(), search.PageNo + 1, search.PageSize, 0);
            foreach (var obj in data)
            {
                obj.id = _Iencryption.EncryptID(obj.id);
            }
            var rdata = _mapper.Map<IEnumerable<MenuModel>>(data.ToArray());
            var mData = data.GetMetaData();
            var pagedList = new StaticPagedList<MenuModel>(rdata, mData);
            return pagedList;
        }

        public MenuModel GetMenuById(string id)
        {
            var res = new MenuEntities();
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            try
            {
                res = _MenuDAL.GetById(Id).Result;
                res.id = _Iencryption.EncryptID(res.id);
            }
            catch (Exception ex)
            {

            }
            return _mapper.Map<MenuModel>(res);
        }

        public async Task<int> CreateMenu(MenuModel entities)
        {                        
            var data = _mapper.Map<MenuEntities>(entities);
            return await _MenuDAL.Create(data);
        }

        public async Task<int> UpdateMenu(MenuModel entities)
        {
            entities.Id = _Iencryption.DecryptID(entities.Id);           
            var data = _mapper.Map<MenuEntities>(entities);
            return await _MenuDAL.Update(data);
        }

        public async Task<int> DeleteMenu(string id)
        {
            int Id = Convert.ToInt32(_Iencryption.DecryptID(id));
            return await _MenuDAL.Delete(Id);
        }
    }
}
