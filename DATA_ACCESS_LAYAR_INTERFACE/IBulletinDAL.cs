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
    public interface IBulletinDAL
    {
        IPagedList<BulletinViewEntities> GetAll(SearchCompanyEntities search);
        Task<BulletinEntities> GetById(int id);
        Task<int> Create(BulletinEntities entity);
        Task<int> Update(BulletinEntities entity);
        Task<int> Delete(int id);
    }
}
