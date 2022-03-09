using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IProjectBAL
    {
        public StaticPagedList<ProjectModel> GetAllProject(SearchCompanyModel search);
        public ProjectModel GetProjectById(string id);
        public Task<int> CreateProject(ProjectModel entities);
        public Task<int> UpdateProject(ProjectModel entities);
        public Task<int> DeleteProject(string id);
    }
}
