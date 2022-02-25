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
    public interface IRoleBAL
    {
        IEnumerable<RoleEntities> GetAllRole();
        public StaticPagedList<RoleModel> GetAllRole(SearchCompanyModel search);
        public RoleModel GetRoleById(string id);
        public Task<int> CreateRole(RoleModel entities);
        public Task<int> UpdateRole(RoleModel entities);
        public Task<int> DeleteRole(string id);
    }
}
