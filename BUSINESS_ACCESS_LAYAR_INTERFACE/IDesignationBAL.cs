using BUSINESS_ENTITIES;
using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IDesignationBAL
    {
        IEnumerable<DesignationEntities> GetAllDesignation();
        public StaticPagedList<DesignationModel> GetAllDesignation(SearchCompanyModel search);
        public DesignationModel GetDesignationById(string id);
        public Task<int> CreateDesignation(DesignationModel entities);
        public Task<int> UpdateDesignation(DesignationModel entities);
        public Task<int> DeleteDesignation(string id);
    }
}
