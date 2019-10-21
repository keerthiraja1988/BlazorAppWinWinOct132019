namespace WebAppBlazorWASM.Pages.Approvals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebAppBlazorWASM.Infrastructure.Services;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using ResourceModel.Authentication;
    using ResourceModel.EmployeeApproval;
    using WebAppBlazorWASM.Services;

    public class ProcessCreateEmployeeBase : ComponentBase
    {
        public long EmployeeRequestId { get; set; } = 0;

        public JwtToken JwtToken { get; set; } = new JwtToken();

        public EmployeePendingApprovalRM PendingApproval { get; set; } = new EmployeePendingApprovalRM();

        public string EmpAppReqStatusId { get; set; }

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
            var pendingApprovals = await this._employeeApprovalService.GetAllEmployeesPendingApprovalsAsync();
            Console.WriteLine(this.EmployeeRequestId);

            this.PendingApproval = pendingApprovals.Where(x => x.EmployeeRequestId == this.EmployeeRequestId).FirstOrDefault();
            Console.WriteLine(this.PendingApproval.EmployeeRequestId.ToString());
        }
    }
}