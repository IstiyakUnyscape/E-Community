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
    public interface IProjectDAL
    {
        IPagedList<ProjectViewModelEntities> GetAllProject(SearchCompanyModel search);
        IPagedList<ProjectEntities> GetAll(SearchCompanyModel search);
        Task<ProjectEntities> GetById(int id);
        Task<int> Create(ProjectEntities entity);
        Task<int> Update(ProjectEntities entity);
        Task<int> Delete(int id);
    }
}
