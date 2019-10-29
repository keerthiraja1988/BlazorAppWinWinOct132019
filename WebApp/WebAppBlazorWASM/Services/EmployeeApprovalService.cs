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

        public async Task<List<EmployeePendingApprovalRM>> GetAllEmployeesOnHoldApprovalsAsync()
        {
            List<EmployeePendingApprovalRM> pendingApprovalsRM = new List<EmployeePendingApprovalRM>();

            string url = await this._appConfigurationService.GetApiUrl("EmployeeManageApi");
            pendingApprovalsRM = await this._httpClient.GetJsonAsync<List<EmployeePendingApprovalRM>>(url + "/api/EmployeeApproval/GetAllEmployeesOnHoldApprovalsAsync");

            return pendingApprovalsRM;
        }

        public async Task<List<EmpAppReqStatusResModel>> GetAllEmpAppReqStatusAsync()
        {
            List<EmpAppReqStatusResModel> empAppReqStatusesEM = new List<EmpAppReqStatusResModel>();

            string url = await this._appConfigurationService.GetApiUrl("EmployeeManageApi");
            empAppReqStatusesEM = await this._httpClient.GetJsonAsync<List<EmpAppReqStatusResModel>>(url + "/api/EmployeeApproval/GetAllEmpAppReqStatusAsync");

            return empAppReqStatusesEM;
        }

        public async Task<(EmployeePendingApprovalRM CreateEmployeeDetails
                        , List<EmpAppReqStatusResModel> ReqStatuses
                        , List<EmployeesReqStatusHistResModel> EmployeesReqStatusHistories)> GetCreateEmployeeReqAsync(long employeeId, long employeeRequestId)
        {
            string url = await this._appConfigurationService.GetApiUrl("EmployeeManageApi");

            string stringJWT = await this._httpClient.GetJsonAsync<string>(url + "/api/EmployeeApproval/GetCreateEmployeeReqAsync?employeeId="
                                    + employeeId
                                    + "&employeeRequestId=" + employeeRequestId
                                );

            var responses = JsonConvert.DeserializeObject<(EmployeePendingApprovalRM
                               , List<EmpAppReqStatusResModel>
                               , List<EmployeesReqStatusHistResModel>)>(stringJWT);

            return (responses.Item1, responses.Item2, responses.Item3);
        }

        public async Task<bool> ProcessCreateEmployeeAsync(ProcessCreateEmployeeRM processCreateEmployeeRM)
        {
            bool isProcessSuccess;
            string url = await this._appConfigurationService.GetApiUrl("EmployeeManageApi");

            string stringData = JsonConvert.SerializeObject(processCreateEmployeeRM);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this._httpClient.PostAsync
                          (url + "/api/EmployeeApproval/ProcessCreateEmployeeAsync", contentData);
            string stringJWT = response.Content.
                                   ReadAsStringAsync().Result;
            isProcessSuccess = JsonConvert.DeserializeObject<bool>(stringJWT);

            return isProcessSuccess;
        }

        public async Task<(EmployeePendingApprovalRM OnHoldEmployeeDetails
                       , List<EmpAppReqStatusResModel> ReqStatuses
                       , List<EmployeesReqStatusHistResModel> EmployeesReqStatusHistories)> GetCreateEmployeeReqOnHoldAsync(long employeeId, long employeeRequestId)
        {
            string url = await this._appConfigurationService.GetApiUrl("EmployeeManageApi");

            string stringJWT = await this._httpClient.GetJsonAsync<string>(url + "/api/EmployeeApproval/GetCreateEmployeeReqOnHoldAsync?employeeId="
                                    + employeeId
                                    + "&employeeRequestId=" + employeeRequestId
                                );

            var responses = JsonConvert.DeserializeObject<(EmployeePendingApprovalRM
                               , List<EmpAppReqStatusResModel>
                               , List<EmployeesReqStatusHistResModel>)>(stringJWT);

            return (responses.Item1, responses.Item2, responses.Item3);
        }
    }
}