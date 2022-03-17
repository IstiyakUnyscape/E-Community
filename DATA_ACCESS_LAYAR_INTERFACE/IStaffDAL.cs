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
    public interface IStaffDAL
    {
        IPagedList<StaffViewEntities> GetAll(SearchCompanyEntities search);
        StaffEntities GetById(int id);
        Task<int> Create(StaffEntities entity);
        Task<int> Update(StaffEntities entity);
        Task<int> Delete(int id);
    }
}
