using AutoMapper;
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
            CreateMap<SearchCompanyEntities, SearchCompanyModel>().ReverseMap();
            CreateMap<CompanyEntities, CompanyModel>().ReverseMap();
            CreateMap<StaffEntities, StaffModel>().ReverseMap();
            CreateMap<StaffViewEntities, StaffViewModel>().ReverseMap();
            CreateMap<VendorsEntities, VendorsModel>().ReverseMap();
            CreateMap<GuestEntities, GuestModel>().ReverseMap();
            CreateMap<DeveloperEntities, DeveloperModel>().ReverseMap();
            CreateMap<DeveloperViewModel, DeveloperViewModel>().ReverseMap();
            CreateMap<UserEntities, UserModel>().ReverseMap();
            CreateMap<DesignationEntities, DesignationModel>().ReverseMap();
            CreateMap<RoleEntities, RoleModel>().ReverseMap();
            CreateMap<BulletinEntities, BulletinModel>().ReverseMap();
            CreateMap<BulletinViewEntities, BulletinViewModel>().ReverseMap();
            CreateMap<EventEntities, EventModel>().ReverseMap();
            CreateMap<EventViewEntities, EventModel>().ReverseMap();
            CreateMap<ProjectEntities, ProjectModel>().ReverseMap();
            CreateMap<ProjectViewModelEntities, ProjectViewModel>().ReverseMap();
            CreateMap<MilestoneEntities, MilestoneModel>().ReverseMap();
            CreateMap<MilestoneViewEntities, MilestoneViewModel>().ReverseMap();
            CreateMap<RiskCategorysEntities, RiskCategorysModel>().ReverseMap();
            CreateMap<RiskRegistryEntities, RiskRegistryModel>().ReverseMap();
            CreateMap<RiskRegistryViewEntities, RiskRegistryViewModel>().ReverseMap();
            CreateMap<NoticesEntities, NoticesModel>().ReverseMap();
            CreateMap<NoticesViewEntities, NoticesModel>().ReverseMap();
            CreateMap<UnitEntities, UnitModel>().ReverseMap();
            CreateMap<MenuEntities, MenuModel>().ReverseMap();


        }
    }
}
