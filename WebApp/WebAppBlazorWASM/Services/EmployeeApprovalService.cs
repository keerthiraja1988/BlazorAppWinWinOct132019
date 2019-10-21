namespace WebAppBlazorWASM.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using Microsoft.AspNetCore.Components.Authorization;
    using WebAppBlazorWASM.Infrastructure.Security;
    using WebAppBlazorWASM.Infrastructure.Services;
    using Blazored.LocalStorage;
    using Newtonsoft.Json;
    using ResourceModel.Api;
    using ResourceModel.Authentication;
    using ResourceModel.EmployeeApproval;
    using ResourceModel.EmployeeManage;

    public class EmployeeApprovalService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;
        private readonly IJSRuntime _jsRuntime;
        private readonly AppConfigurationService _appConfigurationService;

        public EmployeeApprovalService(HttpClient httpClient,
                      AuthenticationStateProvider authenticationStateProvider,
                      ILocalStorageService localStorage, NavigationManager navigationManager
                      , AppConfigurationService appConfigurationService
                      , IJSRuntime ijsRuntime)
        {
            this._httpClient = httpClient;
            this._authenticationStateProvider = authenticationStateProvider;
            this._localStorage = localStorage;
            this._navigationManager = navigationManager;
            this._appConfigurationService = appConfigurationService;
            this._jsRuntime = ijsRuntime;
        }

        public async Task<List<EmployeePendingApprovalRM>> GetAllEmployeesPendingApprovalsAsync()
        {
            List<EmployeePendingApprovalRM> pendingApprovalsRM = new List<EmployeePendingApprovalRM>();

            string url = await this._appConfigurationService.GetApiUrl("EmployeeManageApi");
            pendingApprovalsRM = await this._httpClient.GetJsonAsync<List<EmployeePendingApprovalRM>>(url + "/api/EmployeeApproval/GetAllEmployeesPendingApprovalsAsync");

            return pendingApprovalsRM;
        }
    }
}