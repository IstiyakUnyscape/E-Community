using BUSINESS_ENTITIES;
using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DATA_ACCESS_LAYAR_INTERFACE
{
    public interface IVendorsDAL
    {
        IPagedList<VendorsEntities> GetAll(SearchCompanyModel search);
        VendorsEntities GetById(int id);
        Task<int> Create(VendorsEntities entity);
        Task<int> Update(VendorsEntities entity);
        Task<int> Delete(int id);
    }
}
