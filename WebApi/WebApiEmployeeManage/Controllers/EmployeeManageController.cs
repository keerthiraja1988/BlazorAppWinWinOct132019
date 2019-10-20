using AutoMapper;
using DomainModel;
using DomainModel.EmployeeManage;
using DomainModel.EmployeeManage.Dimension;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ResourceModel.Api;
using ResourceModel.Authentication;
using ResourceModel.EmployeeManage;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiEmployeeManage.Repository;

namespace WebApiEmployeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmployeeManageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeManageController> _logger;
        private readonly IEmployeeManageRepository _employeeManageRepository;

        public EmployeeManageController(IMapper mapper, ILogger<EmployeeManageController> logger, IEmployeeManageRepository employeeManageRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _employeeManageRepository = employeeManageRepository;
        }

        [Authorize]
        [HttpGet("GetAllEmployeeTitlesAsync")]
        public async Task<List<EmployeeTitleResModel>> GetAllEmployeeTitlesAsync()
        {
            List<EmployeeTitleResModel> employeeTitlesResModel = new List<EmployeeTitleResModel>();
            List<EmployeeTitle> employeeTitles = new List<EmployeeTitle>();
            employeeTitles = await this._employeeManageRepository.GetAllEmployeeTitlesAsync();
            employeeTitlesResModel = this._mapper.Map<List<EmployeeTitleResModel>>(employeeTitles);

            return employeeTitlesResModel;
        }

        [Authorize]
        [HttpPost("CreateEmployeeAsync")]
        public async Task<EmployeeResModel> CreateEmployeeAsync(EmployeeResModel createEmployeeRM)
        {
            Employee createEmployee = new Employee();
            createEmployee = this._mapper.Map<Employee>(createEmployeeRM);
            createEmployee = await this._employeeManageRepository.CreateEmployeeAsync(createEmployee, createEmployeeRM.Comments);
            createEmployeeRM = this._mapper.Map<EmployeeResModel>(createEmployee);
            return createEmployeeRM;
        }
    }
}