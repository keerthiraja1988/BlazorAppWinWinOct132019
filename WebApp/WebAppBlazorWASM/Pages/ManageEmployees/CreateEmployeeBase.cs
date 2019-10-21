namespace WebAppBlazorWASM.Pages.ManageEmployees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebAppBlazorWASM.Infrastructure.Services;
    using WebAppBlazorWASM.Services;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using ResourceModel.Authentication;
    using ResourceModel.EmployeeManage;

    public class CreateEmployeeBase : ComponentBase
    {
        public JwtToken JwtToken { get; set; } = new JwtToken();

        public EmployeeResModel EmployeeResModel { get; set; } = new EmployeeResModel();

        public List<EmployeeTitleResModel> EmployeeTitlesResModel { get; set; } = new List<EmployeeTitleResModel>();

        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected EmployeeManageService _employeeManageService { get; set; }

        public async Task OnCreateEmployeeLoad()
        {
            this.EmployeeTitlesResModel = await this._employeeManageService.GetAllEmployeeTitlesAsync();
            this.JwtToken = await this._appSharedService.GetLoggedInUserDetails();
        }

        public async Task OnCreateEmployeeButtonClick()
        {
            await this._jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");
            EmployeeResModel.CreatedBy = this.JwtToken.UserId;
            EmployeeResModel createEmployeeRM = new EmployeeResModel();

            createEmployeeRM = await this._employeeManageService.CreateEmployeeAsync(EmployeeResModel);

            if (createEmployeeRM.EmployeeId > 0)
            {
                await this.OnCleareCreateEmployeeButtonClick();
                await this._jsRuntime.InvokeVoidAsync("homeController.showSuccessToastNotification",
                    "Employee (" + createEmployeeRM.EmployeeId + ") successfully created");
            }

            await this._jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task OnCleareCreateEmployeeButtonClick()
        {
            EmployeeResModel = new EmployeeResModel();
        }
    }
}