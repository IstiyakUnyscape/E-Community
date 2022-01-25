using BUSINESS_ENTITIES;
using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IVendorsBAL
    {
        public StaticPagedList<VendorsModel> GetAllVendors(SearchCompanyModel search);
        public VendorsModel GetVendorsById(string id);
        public Task<int> CreateVendors(VendorsModel entities);
        public Task<int> UpdateVendors(VendorsModel entities);
        public Task<int> DeleteVendors(string id);
    }
}
