using AutoMapper;
using DomainModel;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClaimsA.Infrastructure
{
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