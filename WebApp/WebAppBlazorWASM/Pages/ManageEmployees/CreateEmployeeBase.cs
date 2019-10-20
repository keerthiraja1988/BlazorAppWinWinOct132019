using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using ResourceModel.EmployeeManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Services;
using WebAppBlazorWASM.Services;

namespace WebAppBlazorWASM.Pages.ManageEmployees
{
    public class CreateEmployeeBase : ComponentBase
    {
        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected EmployeeManageService _employeeManageService { get; set; }

        public JwtToken jwtToken { get; set; } = new JwtToken();

        public EmployeeResModel EmployeeResModel { get; set; } = new EmployeeResModel();

        public List<EmployeeTitleResModel> EmployeeTitlesResModel { get; set; } = new List<EmployeeTitleResModel>();

        public async Task OnCreateEmployeeLoad()
        {
            EmployeeTitlesResModel = await _employeeManageService.GetAllEmployeeTitlesAsync();
            jwtToken = await _appSharedService.GetLoggedInUserDetails();
        }

        public async Task OnCreateEmployeeButtonClick()
        {
            await _jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");
            EmployeeResModel.CreatedBy = jwtToken.UserId;
            EmployeeResModel createEmployeeRM = new EmployeeResModel();

            createEmployeeRM = await _employeeManageService.CreateEmployeeAsync(EmployeeResModel);

            if (createEmployeeRM.EmployeeId > 0)
            {
                await OnCleareCreateEmployeeButtonClick();
                await _jsRuntime.InvokeVoidAsync("homeController.showSuccessToastNotification",
                    "Employee (" + createEmployeeRM.EmployeeId + ") successfully created");
            }

            await _jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task OnCleareCreateEmployeeButtonClick()
        {
            EmployeeResModel = new EmployeeResModel();
        }
    }
}