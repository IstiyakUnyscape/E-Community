﻿using AutoMapper;
using BUSINESS_ENTITIES;
using CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CompanyEntities, CompanyModel>().ReverseMap();
            CreateMap<StaffEntities, StaffModel>().ReverseMap();
            CreateMap<VendorsEntities, VendorsModel>().ReverseMap();
            CreateMap<GuestEntities, GuestModel>().ReverseMap();
            CreateMap<DeveloperEntities, DeveloperModel>().ReverseMap();
            CreateMap<UserEntities, UserModel>().ReverseMap();
            CreateMap<DesignationEntities, DesignationModel>().ReverseMap();
            CreateMap<RoleEntities, RoleModel>().ReverseMap();
        }
    }
}
