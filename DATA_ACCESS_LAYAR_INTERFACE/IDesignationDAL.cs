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
    public interface IDesignationDAL
    {
        IEnumerable<DesignationEntities> GetAll();
        IPagedList<DesignationEntities> GetAll(SearchCompanyModel search);
        Task<DesignationEntities> GetById(int id);
        Task<int> Create(DesignationEntities entity);
        Task<int> Update(DesignationEntities entity);
        Task<int> Delete(int id);
    }
}
