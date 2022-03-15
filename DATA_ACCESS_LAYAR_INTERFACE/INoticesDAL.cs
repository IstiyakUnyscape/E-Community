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
    public interface INoticesDAL
    {
        IPagedList<NoticesEntities> GetAll(SearchCompanyModel search);
        Task<NoticesEntities> GetById(int id);
        Task<int> Create(NoticesEntities entity);
        Task<int> Update(NoticesEntities entity);
        Task<int> Delete(int id);
    }
}
