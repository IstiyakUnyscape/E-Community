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
    public interface IRiskRegistryDAL
    {
        IPagedList<RiskRegistryViewEntities> GetAll(SearchCompanyEntities search);
        Task<RiskRegistryEntities> GetById(int id);
        Task<int> Create(RiskRegistryEntities entity);
        Task<int> Update(RiskRegistryEntities entity);
        Task<int> Delete(int id);
    }
}
