using AutoMapper;
using DomainModel;
using DomainModel.EmployeeManage;
using DomainModel.EmployeeManage.Dimension;
using ResourceModel.Authentication;
using ResourceModel.EmployeeManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEmployeeManage.Infrastructure
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<EmployeeResModel, Employee>().ReverseMap();
            CreateMap<EmployeeResModel, EmployeeRequest>().ReverseMap();
            CreateMap<EmployeesReqStatusHistResModel, EmployeesReqStatusHistory>().ReverseMap();
            CreateMap<EmpAppOprStatusResModel, EmpAppOprStatus>().ReverseMap();
            CreateMap<EmpAppReqStatusResModel, EmpAppReqStatus>().ReverseMap();
            CreateMap<EmployeeTitleResModel, EmployeeTitle>().ReverseMap();
        }
    }
}