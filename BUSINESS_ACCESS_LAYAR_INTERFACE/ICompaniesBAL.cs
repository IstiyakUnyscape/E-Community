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
    public interface ICompaniesBAL
    {
        IEnumerable<CompanyEntities> GetAllCompany();
        public StaticPagedList<CompanyModel> GetAllCompany(SearchCompanyModel search);
        public CompanyModel GetCompanyById(string id);
        public Task<int> CreateCompany(CompanyModel entities);
        public Task<int> UpdateCompany(CompanyModel entities);
        public Task<int> DeleteCompany(string id);
    }
}
