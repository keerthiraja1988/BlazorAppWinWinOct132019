using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using ResourceModel.Api;
using ResourceModel.Authentication;
using ResourceModel.EmployeeApproval;
using ResourceModel.EmployeeManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Security;
using WebAppBlazorWASM.Infrastructure.Services;

namespace WebAppBlazorWASM.Services
{
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
                      , IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            _appConfigurationService = appConfigurationService;
            _jsRuntime = jsRuntime;
        }

        public async Task<List<EmployeePendingApprovalRM>> GetAllEmployeesPendingApprovalsAsync()
        {
            List<EmployeePendingApprovalRM> pendingApprovalsRM = new List<EmployeePendingApprovalRM>();

            string url = await _appConfigurationService.GetApiUrl("EmployeeManageApi");
            pendingApprovalsRM = await _httpClient.GetJsonAsync<List<EmployeePendingApprovalRM>>(url + "/api/EmployeeApproval/GetAllEmployeesPendingApprovalsAsync");

            return pendingApprovalsRM;
        }
    }
}