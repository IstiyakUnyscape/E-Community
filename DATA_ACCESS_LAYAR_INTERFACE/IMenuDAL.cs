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
    public interface IMenuDAL
    {
        IPagedList<MenuEntities> GetAll(SearchCompanyModel search);
        Task<MenuEntities> GetById(int id);
        Task<int> Create(MenuEntities entity);
        Task<int> Update(MenuEntities entity);
        Task<int> Delete(int id);
    }
}
