using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IEventBAL
    {
        public StaticPagedList<EventModel> GetAllEvent(SearchCompanyModel search);
        public EventModel GetEventById(string id);
        public Task<int> CreateEvent(EventModel entities);
        public Task<int> UpdateEvent(EventModel entities);
        public Task<int> DeleteEvent(string id);
    }
}
