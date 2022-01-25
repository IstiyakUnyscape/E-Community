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
    public interface IGuestDAL
    {
        IPagedList<GuestEntities> GetAll(SearchCompanyModel search);
        Task<GuestEntities> GetById(int id);
        Task<int> Create(GuestEntities entity);
        Task<int> Update(GuestEntities entity);
        Task<int> Delete(int id);
    }
}
