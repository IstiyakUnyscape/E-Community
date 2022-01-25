using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IDeveloperBAL
    {
        public StaticPagedList<DeveloperModel> GetAllDeveloper(SearchCompanyModel search);
        public DeveloperModel GetDeveloperById(string id);
        public Task<int> CreateDeveloper(DeveloperModel entities);
        public Task<int> UpdateDeveloper(DeveloperModel entities);
        public Task<int> DeleteDeveloper(string id);
    }
}
