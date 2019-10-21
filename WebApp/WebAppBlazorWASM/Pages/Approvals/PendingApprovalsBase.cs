namespace WebAppBlazorWASM.Pages.Approvals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using ResourceModel.Authentication;
    using ResourceModel.EmployeeApproval;
    using ResourceModel.EmployeeManage;
    using WebAppBlazorWASM.Infrastructure.Services;
    using WebAppBlazorWASM.Services;

    public class PendingApprovalsBase : ComponentBase
    {
        public List<EmployeePendingApprovalRM> PendingApprovals { get; set; } = new List<EmployeePendingApprovalRM>();

        public JwtToken JwtToken { get; set; } = new JwtToken();

        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected EmployeeApprovalService _employeeApprovalService { get; set; }

        public async Task OnPendingApprovalsLoad()
        {
            this.JwtToken = await this._appSharedService.GetLoggedInUserDetails();
            this.PendingApprovals = await this._employeeApprovalService.GetAllEmployeesPendingApprovalsAsync();
        }
    }
}