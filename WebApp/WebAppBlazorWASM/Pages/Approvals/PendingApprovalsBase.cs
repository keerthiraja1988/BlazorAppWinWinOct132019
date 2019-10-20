using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using ResourceModel.EmployeeApproval;
using ResourceModel.EmployeeManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Services;
using WebAppBlazorWASM.Services;

namespace WebAppBlazorWASM.Pages.Approvals
{
    public class PendingApprovalsBase : ComponentBase
    {
        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected EmployeeApprovalService _employeeApprovalService { get; set; }

        public JwtToken jwtToken { get; set; } = new JwtToken();

        public List<EmployeePendingApprovalRM> PendingApprovals { get; set; } = new List<EmployeePendingApprovalRM>();

        public async Task OnPendingApprovalsLoad()
        {
            jwtToken = await _appSharedService.GetLoggedInUserDetails();
            PendingApprovals = await _employeeApprovalService.GetAllEmployeesPendingApprovalsAsync();
        }
    }
}