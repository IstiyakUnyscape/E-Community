﻿using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ACCESS_LAYAR_INTERFACE
{
    public interface IUserBAL
    {
        Task<UserModel> UserLogin(LoginEntitiies obj);
        public Task<int> CreateUser(string obj);
    }
}