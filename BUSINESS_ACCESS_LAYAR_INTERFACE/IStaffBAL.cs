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
    public interface IStaffBAL
    {
        public StaticPagedList<StaffViewModel> GetAllStaff(SearchCompanyModel search);
        public StaffModel GetStaffById(string id);
        public Task<string> CreateStaff(StaffModel entities);
        public Task<int> UpdateStaff(StaffModel entities);
        public Task<int> DeleteStaff(string id);
    }
}
