using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IGuestBAL
    {
        public StaticPagedList<GuestModel> GetAllGuest(SearchCompanyModel search);
        public GuestModel GetGuestById(string id);
        public Task<int> CreateGuest(GuestModel entities);
        public Task<int> UpdateGuest(GuestModel entities);
        public Task<int> DeleteGuest(string id);
    }
}
