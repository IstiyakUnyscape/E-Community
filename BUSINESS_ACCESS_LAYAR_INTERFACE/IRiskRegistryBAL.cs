using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IRiskRegistryBAL
    {
        public StaticPagedList<RiskRegistryViewModel> GetAllRiskRegistry(SearchCompanyModel search);
        public RiskRegistryModel GetRiskRegistryById(string id);
        public Task<int> CreateRiskRegistry(RiskRegistryModel entities);
        public Task<int> UpdateRiskRegistry(RiskRegistryModel entities);
        public Task<int> DeleteRiskRegistry(string id);
    }
}
