using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IMilestoneBAL
    {
        public StaticPagedList<MilestoneViewModel> GetAllMilestone(SearchCompanyModel search);
        public MilestoneModel GetMilestoneById(string id);
        public IEnumerable<MilestoneViewModel> GetMilestoneByProjectId(int id);
        public Task<int> CreateMilestone(MilestoneModel entities);
        public Task<int> UpdateMilestone(MilestoneModel entities);
        public Task<int> DeleteMilestone(string id);
        bool ValidateStartEndDtae(int ProjectId, DateTime StartDate, DateTime EndDatetDate);
    }
}
