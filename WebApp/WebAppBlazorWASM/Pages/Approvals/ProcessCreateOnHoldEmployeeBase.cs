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
    using System.Threading;

    public class ProcessCreateOnHoldEmployeeBase : ComponentBase
    {
        public long EmployeeRequestId { get; set; } = 0;

        public long EmployeeId { get; set; } = 0;

        public EmployeePendingApprovalRM PendingApproval { get; set; } = new EmployeePendingApprovalRM();

        public List<EmpAppReqStatusResModel> EmpAppReqStatusesRM { get; set; } = new List<EmpAppReqStatusResModel>();

        public List<EmployeesReqStatusHistResModel> EmployeesReqStatusHistoriesRM { get; set; } = new List<EmployeesReqStatusHistResModel>();

        public string EmpAppReqStatusId { get; set; }

        public ProcessCreateEmployeeRM ProcessCreateEmployeeRM { get; set; } = new ProcessCreateEmployeeRM();

        public JwtToken JwtToken { get; set; } = new JwtToken();

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

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

            var employeeDetails = await this._employeeApprovalService.GetCreateEmployeeReqOnHoldAsync(EmployeeId, EmployeeRequestId);

            this.EmpAppReqStatusesRM = employeeDetails.ReqStatuses;
            this.PendingApproval = employeeDetails.CreateEmployeeDetails;
            this.EmployeesReqStatusHistoriesRM = employeeDetails.EmployeesReqStatusHistories;

            this.ProcessCreateEmployeeRM.EmployeeId = this.PendingApproval.EmployeeId.ToString();
            this.ProcessCreateEmployeeRM.EmployeeRequestId = this.PendingApproval.EmployeeRequestId.ToString();
            this.ProcessCreateEmployeeRM.CreatedBy = this.JwtToken.UserId;

            Console.WriteLine("asfdsad " + PendingApproval.EmployeeId.ToString());
        }

        public async Task OnProcessCreateEmployeeBtnClick()
        {
            await this._jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");

            var isProcessSuccess = await this._employeeApprovalService.ProcessCreateEmployeeAsync(this.ProcessCreateEmployeeRM);

            if (isProcessSuccess)
            {
                await this._jsRuntime.InvokeVoidAsync("approvalsController.ProcessCreateEmployeeSuccessModalShow"
                                , "");
            }

            await this._jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task OnProcessCreateEmployeeCloseBtnClick()
        {
            this._navigationManager.NavigateTo("PendingApprovals");

            await this._jsRuntime.InvokeVoidAsync("approvalsController.ProcessCreateEmployeeSuccessModalHide"
                               , "");
        }
    }
}