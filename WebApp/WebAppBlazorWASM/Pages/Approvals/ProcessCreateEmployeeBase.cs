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
    using ResourceModel.EmployeeManage;

    public class ProcessCreateEmployeeBase : ComponentBase
    {
        public long EmployeeRequestId { get; set; } = 0;

        public EmployeePendingApprovalRM PendingApproval { get; set; } = new EmployeePendingApprovalRM();

        public List<EmpAppReqStatusResModel> EmpAppReqStatusesRM { get; set; } = new List<EmpAppReqStatusResModel>();

        public string EmpAppReqStatusId { get; set; }

        public ProcessCreateEmployeeRM ProcessCreateEmployeeRM { get; set; } = new ProcessCreateEmployeeRM();

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
            var task1 = this._employeeApprovalService.GetAllEmployeesPendingApprovalsAsync();
            var task2 = this._employeeApprovalService.GetAllEmpAppReqStatusAsync();

            await Task.WhenAll(task1, task2);

            var pendingApprovals = await task1;
            this.EmpAppReqStatusesRM = await task2;
            this.PendingApproval = pendingApprovals.Where(x => x.EmployeeRequestId == this.EmployeeRequestId).FirstOrDefault();
        }

        public async Task OnProcessCreateEmployeeBtnClick()
        {
            Console.WriteLine(ProcessCreateEmployeeRM.Comments);
        }
    }
}