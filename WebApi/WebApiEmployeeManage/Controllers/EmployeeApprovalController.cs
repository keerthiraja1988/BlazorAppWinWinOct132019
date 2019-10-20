using AutoMapper;
using DomainModel;
using DomainModel.EmployeeApproval;
using DomainModel.EmployeeManage;
using DomainModel.EmployeeManage.Dimension;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ResourceModel.Api;
using ResourceModel.Authentication;
using ResourceModel.EmployeeApproval;
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
    public class EmployeeApprovalController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeApprovalController> _logger;
        private readonly IEmployeeApprovalRepository _employeeApprovalRepository;

        public EmployeeApprovalController(IMapper mapper, ILogger<EmployeeApprovalController> logger, IEmployeeApprovalRepository employeeApprovalRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _employeeApprovalRepository = employeeApprovalRepository;
        }

        [Authorize]
        [HttpGet("GetAllEmployeesPendingApprovalsAsync")]
        public async Task<List<EmployeePendingApprovalRM>> GetAllEmployeesPendingApprovalsAsync()
        {
            List<EmployeePendingApprovalRM> pendingApprovalsRM = new List<EmployeePendingApprovalRM>();
            List<EmployeePendingApproval> pendingApprovals = new List<EmployeePendingApproval>();

            pendingApprovals = await this._employeeApprovalRepository.GetAllEmployeesPendingApprovalsAsync();
            pendingApprovalsRM = this._mapper.Map<List<EmployeePendingApprovalRM>>(pendingApprovals);
            return pendingApprovalsRM;
        }
    }
}