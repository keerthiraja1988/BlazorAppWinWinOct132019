using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using ResourceModel.EmployeeApproval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Services;
using WebAppBlazorWASM.Services;

namespace WebAppBlazorWASM.Pages.Approvals
{
    public class ProcessCreateEmployeeBase : ComponentBase
    {
        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected EmployeeApprovalService _employeeApprovalService { get; set; }

        public Int64 EmployeeRequestId { get; set; } = 0;

        public JwtToken jwtToken { get; set; } = new JwtToken();

        public EmployeePendingApprovalRM PendingApproval { get; set; } = new EmployeePendingApprovalRM();

        public string EmpAppReqStatusId { get; set; }

        public async Task OnPendingApprovalsLoad()
        {
            jwtToken = await _appSharedService.GetLoggedInUserDetails();
            var pendingApprovals = await _employeeApprovalService.GetAllEmployeesPendingApprovalsAsync();
            Console.WriteLine(EmployeeRequestId);

            PendingApproval = pendingApprovals.Where(x => x.EmployeeRequestId == EmployeeRequestId).FirstOrDefault();
            Console.WriteLine(PendingApproval.EmployeeRequestId.ToString());
        }
    }
}