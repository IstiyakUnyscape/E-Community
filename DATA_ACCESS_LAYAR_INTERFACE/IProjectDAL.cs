using BUSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DATA_ACCESS_LAYAR_INTERFACE
{
    public interface IProjectDAL
    {
        IPagedList<ProjectViewModelEntities> GetAllProject(SearchCompanyEntities search);
        IPagedList<ProjectEntities> GetAll(SearchCompanyEntities search);
        Task<ProjectEntities> GetById(int id);
        Task<int> Create(ProjectEntities entity);
        Task<int> Update(ProjectEntities entity);
        Task<int> Delete(int id);
    }
}
