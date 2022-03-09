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
    public interface IMilestoneDAL
    {
        IPagedList<MilestoneEntities> GetAll(SearchCompanyModel search);
        Task<MilestoneEntities> GetById(int id);
        IEnumerable<MilestoneEntities> GetAll();
        Task<int> Create(MilestoneEntities entity);
        Task<int> Update(MilestoneEntities entity);
        Task<int> Delete(int id);
    }
}
