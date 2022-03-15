using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface INoticesBAL
    {
        public StaticPagedList<NoticesModel> GetAllNotices(SearchCompanyModel search);
        public NoticesModel GetNoticesById(string id);
        public Task<int> CreateNotices(NoticesModel entities);
        public Task<int> UpdateNotices(NoticesModel entities);
        public Task<int> DeleteNotices(string id);
    }
}
