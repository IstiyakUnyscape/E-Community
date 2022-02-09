using BUSINESS_ENTITIES;
using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_ACCESS_LAYAR_INTERFACE
{
    public interface IUserDAL
    {
       UserEntities Login(LoginEntitiies _obj);
       Task<int> Create(UserEntities entity);
    }
}
