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

        public long EmployeeRequestId { get; set; } = 0;

        public long EmployeeId { get; set; } = 0;

        public List<EmpAppReqStatusResModel> EmpAppReqStatusesRM { get; set; } = new List<EmpAppReqStatusResModel>();

        public List<EmployeesReqStatusHistResModel> EmployeesReqStatusHistoriesRM { get; set; } = new List<EmployeesReqStatusHistResModel>();

        public EmployeePendingApprovalRM OnHoldApproval { get; set; } = new EmployeePendingApprovalRM();

        public ProcessCreateEmployeeRM ProcessOnHoldEmployeeRM { get; set; } = new ProcessCreateEmployeeRM();

        public JwtToken JwtToken { get; set; } = new JwtToken();

        public async Task ProcessCreateOnHoldEmployeeOnLoad()
        {
            this.JwtToken = await this._appSharedService.GetLoggedInUserDetails();

            var employeeDetails = await this._employeeApprovalService.GetCreateEmployeeReqOnHoldAsync(EmployeeId, EmployeeRequestId);

            this.OnHoldApproval = employeeDetails.OnHoldEmployeeDetails;
            this.EmpAppReqStatusesRM = employeeDetails.ReqStatuses;
            this.EmployeesReqStatusHistoriesRM = employeeDetails.EmployeesReqStatusHistories;

            this.ProcessOnHoldEmployeeRM.EmployeeId = this.OnHoldApproval.EmployeeId.ToString();
            this.ProcessOnHoldEmployeeRM.EmployeeRequestId = this.OnHoldApproval.EmployeeRequestId.ToString();
            this.ProcessOnHoldEmployeeRM.CreatedBy = this.JwtToken.UserId;
        }

        public async Task OnProcessOnHoldEmployeeBtnClick()
        {
            await this._jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");

            //    var isProcessSuccess = await this._employeeApprovalService.ProcessCreateEmployeeAsync(this.ProcessCreateEmployeeRM);

            //    if (isProcessSuccess)
            //    {
            //        await this._jsRuntime.InvokeVoidAsync("approvalsController.ProcessCreateEmployeeSuccessModalShow"
            //                        , "");
            //    }

            //    await this._jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task OnProcessOnHoldEmployeeCloseBtnClick()
        {
            this._navigationManager.NavigateTo("PendingApprovals");

            await this._jsRuntime.InvokeVoidAsync("approvalsController.ProcessCreateEmployeeSuccessModalHide"
                               , "");
        }
    }
}