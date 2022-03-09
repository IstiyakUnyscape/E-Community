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
    public interface IRiskCategorysDAL
    {
        IEnumerable<RiskCategorysEntities> GetAll();
        IPagedList<RiskCategorysEntities> GetAll(SearchCompanyModel search);
        Task<RiskCategorysEntities> GetById(int id);
        Task<int> Create(RiskCategorysEntities entity);
        Task<int> Update(RiskCategorysEntities entity);
        Task<int> Delete(int id);
    }
}
