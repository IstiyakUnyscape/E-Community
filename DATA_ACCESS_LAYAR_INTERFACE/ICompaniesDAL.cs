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
    public interface ICompaniesDAL
    {
        IEnumerable<CompanyEntities> GetAll();
        IPagedList<CompanyEntities> GetAll(SearchCompanyModel search);
        Task<CompanyEntities> GetById(int id);
        Task<int> Create(CompanyEntities entity);
        Task<int> Update(CompanyEntities entity);
        Task<int> Delete(int id);
    }
}
