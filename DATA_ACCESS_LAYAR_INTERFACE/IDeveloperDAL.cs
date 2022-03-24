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
    public interface IDeveloperDAL
    {
        IPagedList<DeveloperViewEntities> GetAll(SearchCompanyEntities search);
        Task<DeveloperEntities> GetById(int id);
        Task<int> Create(DeveloperEntities entity);
        Task<int> Update(DeveloperEntities entity);
        Task<int> Delete(int id);
    }
}
