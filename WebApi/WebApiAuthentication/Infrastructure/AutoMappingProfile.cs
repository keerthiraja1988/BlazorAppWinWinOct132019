namespace WebApiAuthentication.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using DomainModel;
    using ResourceModel.Authentication;

    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<UserDetailResModel, UserDetailModel>().ReverseMap();
            CreateMap<RegisterUserResModel, UserDetailModel>().ReverseMap();
        }
    }
}