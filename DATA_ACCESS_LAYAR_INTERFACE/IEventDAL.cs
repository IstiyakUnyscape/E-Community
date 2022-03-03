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
    public interface IEventDAL
    {
        IPagedList<EventEntities> GetAll(SearchCompanyModel search);
        Task<EventEntities> GetById(int id);
        Task<int> Create(EventEntities entity);
        Task<int> Update(EventEntities entity);
        Task<int> Delete(int id);
    }
}
