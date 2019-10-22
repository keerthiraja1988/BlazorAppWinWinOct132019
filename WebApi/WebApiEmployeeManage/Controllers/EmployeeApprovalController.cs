namespace WebApiEmployeeManage.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Text;
    using System.Text.RegularExpressions;
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
    using Newtonsoft.Json;
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
        [HttpGet("GetAllEmployeesOnHoldApprovalsAsync")]
        public async Task<List<EmployeePendingApprovalRM>> GetAllEmployeesOnHoldApprovalsAsync()
        {
            List<EmployeePendingApprovalRM> pendingApprovalsRM = new List<EmployeePendingApprovalRM>();
            List<EmployeePendingApproval> pendingApprovals = new List<EmployeePendingApproval>();

            pendingApprovals = await this._employeeApprovalRepository.GetAllEmployeesOnHoldApprovalsAsync();
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
        [HttpGet("GetCreateEmployeeReqAsync")]
        public async Task<ActionResult<string>> GetCreateEmployeeReqAsync(long employeeId, long employeeRequestId)
        {
            EmployeePendingApprovalRM empAppReqStatusEM = new EmployeePendingApprovalRM();
            EmployeePendingApproval empAppReqStatus = new EmployeePendingApproval();

            List<EmpAppReqStatus> empAppReqStatues = new List<EmpAppReqStatus>();
            List<EmpAppReqStatusResModel> empAppReqStatusesEM = new List<EmpAppReqStatusResModel>();

            List<EmployeesReqStatusHistory> employeesReqStatusHistories = new List<EmployeesReqStatusHistory>();
            List<EmployeesReqStatusHistResModel> employeesReqStatusHistoriesRM = new List<EmployeesReqStatusHistResModel>();

            var task1 = this._employeeApprovalRepository.GetCreateEmployeeReqAsync(employeeRequestId);
            var task2 = this._employeeApprovalRepository.GetAllEmpAppReqStatusAsync();
            var task3 = this._employeeApprovalRepository.GetEmployeeReqStatusHistory(employeeId, employeeRequestId);

            await Task.WhenAll(task1, task2, task3);

            empAppReqStatus = await task1;
            empAppReqStatues = await task2;
            employeesReqStatusHistories = await task3;

            empAppReqStatusEM = this._mapper.Map<EmployeePendingApprovalRM>(empAppReqStatus);

            empAppReqStatusesEM = this._mapper.Map<List<EmpAppReqStatusResModel>>(empAppReqStatues);
            employeesReqStatusHistoriesRM = this._mapper.Map<List<EmployeesReqStatusHistResModel>>(employeesReqStatusHistories);

            empAppReqStatusesEM = empAppReqStatusesEM.Where(x => x.EmpAppReqStatusId != 100).ToList();  //100	Submitted

            //return Ok(JsonConvert.SerializeObject((empAppReqStatusEM, empAppReqStatusesEM, employeesReqStatusHistoriesRM)));

            string stringValue = JsonConvert.SerializeObject((empAppReqStatusEM, empAppReqStatusesEM, employeesReqStatusHistoriesRM));

            var responses = JsonConvert.DeserializeObject<(EmployeePendingApprovalRM, List<EmpAppReqStatusResModel>, List<EmployeesReqStatusHistResModel>)>(stringValue);

            return Ok(stringValue);
        }

        [Authorize]
        [HttpGet("GetCreateEmployeeReqOnHoldAsync")]
        public async Task<ActionResult<string>> GetCreateEmployeeReqOnHoldAsync(long employeeId, long employeeRequestId)
        {
            EmployeePendingApprovalRM empAppReqStatusEM = new EmployeePendingApprovalRM();
            EmployeePendingApproval empAppReqStatus = new EmployeePendingApproval();

            List<EmpAppReqStatus> empAppReqStatues = new List<EmpAppReqStatus>();
            List<EmpAppReqStatusResModel> empAppReqStatusesEM = new List<EmpAppReqStatusResModel>();

            List<EmployeesReqStatusHistory> employeesReqStatusHistories = new List<EmployeesReqStatusHistory>();
            List<EmployeesReqStatusHistResModel> employeesReqStatusHistoriesRM = new List<EmployeesReqStatusHistResModel>();

            var task1 = this._employeeApprovalRepository.GetCreateEmployeeReqOnHoldAsync(employeeRequestId);
            var task2 = this._employeeApprovalRepository.GetAllEmpAppReqStatusAsync();
            var task3 = this._employeeApprovalRepository.GetEmployeeReqStatusHistory(employeeId, employeeRequestId);

            await Task.WhenAll(task1, task2, task3);

            empAppReqStatus = await task1;
            empAppReqStatues = await task2;
            employeesReqStatusHistories = await task3;

            empAppReqStatusEM = this._mapper.Map<EmployeePendingApprovalRM>(empAppReqStatus);

            empAppReqStatusesEM = this._mapper.Map<List<EmpAppReqStatusResModel>>(empAppReqStatues);
            employeesReqStatusHistoriesRM = this._mapper.Map<List<EmployeesReqStatusHistResModel>>(employeesReqStatusHistories);

            empAppReqStatusesEM = empAppReqStatusesEM.Where(x => x.EmpAppReqStatusId != 100).ToList();  //100	Submitted

            //return Ok(JsonConvert.SerializeObject((empAppReqStatusEM, empAppReqStatusesEM, employeesReqStatusHistoriesRM)));

            string stringValue = JsonConvert.SerializeObject((empAppReqStatusEM, empAppReqStatusesEM, employeesReqStatusHistoriesRM));

            var responses = JsonConvert.DeserializeObject<(EmployeePendingApprovalRM, List<EmpAppReqStatusResModel>, List<EmployeesReqStatusHistResModel>)>(stringValue);

            return Ok(stringValue);
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