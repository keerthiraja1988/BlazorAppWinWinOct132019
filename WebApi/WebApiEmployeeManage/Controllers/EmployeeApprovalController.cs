namespace WebApiEmployeeManage.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
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
    using WebApiEmployeeManage.Repository;

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
            this._mapper = mapper;
            this._logger = logger;
            this._employeeApprovalRepository = employeeApprovalRepository;
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

        [Authorize]
        [HttpGet("GetAllEmpAppReqStatusAsync")]
        public async Task<List<EmpAppReqStatusResModel>> GetAllEmpAppReqStatusAsync()
        {
            List<EmpAppReqStatus> empAppReqStatues = new List<EmpAppReqStatus>();
            List<EmpAppReqStatusResModel> empAppReqStatusesEM = new List<EmpAppReqStatusResModel>();
            empAppReqStatues = await this._employeeApprovalRepository.GetAllEmpAppReqStatusAsync();
            empAppReqStatusesEM = this._mapper.Map<List<EmpAppReqStatusResModel>>(empAppReqStatues);
            return empAppReqStatusesEM;
        }

        [Authorize]
        [HttpPost("ProcessCreateEmployeeAsync")]
        public async Task<bool> ProcessCreateEmployeeAsync(ProcessCreateEmployeeRM processCreateEmployeeRM)
        {
            EmployeePendingApproval processCreateEmployee = new EmployeePendingApproval();
            processCreateEmployee = this._mapper.Map<EmployeePendingApproval>(processCreateEmployeeRM);

            return await this._employeeApprovalRepository.ProcessCreateEmployeeAsync(processCreateEmployee);
        }
    }
}