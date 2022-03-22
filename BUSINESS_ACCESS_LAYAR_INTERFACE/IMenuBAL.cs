using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IMenuBAL
    {
        public StaticPagedList<MenuModel> GetAllMenu(SearchCompanyModel search);
        public MenuModel GetMenuById(string id);
        public Task<int> CreateMenu(MenuModel entities);
        public Task<int> UpdateMenu(MenuModel entities);
        public Task<int> DeleteMenu(string id);
    }
}
