using AutoMapper;
using DomainModel;
using DomainModel.ClaimsA.Create;
using ResourceModel.Authentication;
using ResourceModel.ClaimsA.Create;
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

            CreateMap<CreateClaimsAResModel, ClaimAItemModel>().ReverseMap();
        }
    }
}