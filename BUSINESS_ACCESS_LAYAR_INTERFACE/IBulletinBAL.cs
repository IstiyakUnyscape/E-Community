using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IBulletinBAL
    {
        public StaticPagedList<BulletinModel> GetAllBulletin(SearchCompanyModel search);
        public BulletinModel GetBulletinById(string id);
        public Task<int> CreateBulletin(BulletinModel entities);
        public Task<int> UpdateBulletin(BulletinModel entities);
        public Task<int> DeleteBulletin(string id);
    }
}
