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
    public interface IRiskCategorysBAL
    {
        IEnumerable<RiskCategorysEntities> GetAllRiskCategorys();
        public StaticPagedList<RiskCategorysModel> GetAllRiskCategorys(SearchCompanyModel search);
        public RiskCategorysModel GetRiskCategorysById(string id);
        public Task<int> CreateRiskCategorys(RiskCategorysModel entities);
        public Task<int> UpdateRiskCategorys(RiskCategorysModel entities);
        public Task<int> DeleteRiskCategorys(string id);
    }
}
