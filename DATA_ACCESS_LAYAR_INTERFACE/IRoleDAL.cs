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
    public interface IRoleDAL
    {
        IEnumerable<RoleEntities> GetAll();
        IPagedList<RoleEntities> GetAll(SearchCompanyModel search);
        Task<RoleEntities> GetById(int id);
        Task<int> Create(RoleEntities entity);
        Task<int> Update(RoleEntities entity);
        Task<int> Delete(int id);
    }
}
