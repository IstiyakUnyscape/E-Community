using System;

namespace AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CompanyEntities, CompanyModel>().ReverseMap();
            CreateMap<CompanyEntities, CompanyModel>().ReverseMap();
            CreateMap<VendorsEntities, VendorsModel>().ReverseMap();
        }
    }
}
