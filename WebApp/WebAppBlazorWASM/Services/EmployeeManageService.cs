namespace WebAppBlazorWASM.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using WebAppBlazorWASM.Infrastructure.Security;
    using WebAppBlazorWASM.Infrastructure.Services;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Newtonsoft.Json;
    using ResourceModel.Api;
    using ResourceModel.Authentication;
    using ResourceModel.EmployeeManage;

    public class EmployeeManageService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;
        private readonly IJSRuntime _jsRuntime;
        private readonly AppConfigurationService _appConfigurationService;

        public EmployeeManageService(HttpClient httpClient,
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

        public async Task<List<EmployeeTitleResModel>> GetAllEmployeeTitlesAsync()
        {
            List<EmployeeTitleResModel> employeeTitlesResModel = new List<EmployeeTitleResModel>();
            string url = await this._appConfigurationService.GetApiUrl("EmployeeManageApi");
            employeeTitlesResModel = await this._httpClient.GetJsonAsync<List<EmployeeTitleResModel>>(url + "/api/EmployeeManage/GetAllEmployeeTitlesAsync");

            return employeeTitlesResModel;
        }

        public async Task<EmployeeResModel> CreateEmployeeAsync(EmployeeResModel createEmployeeRM)
        {
            string url = await this._appConfigurationService.GetApiUrl("EmployeeManageApi");

            string stringData = JsonConvert.SerializeObject(createEmployeeRM);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this._httpClient.PostAsync
                          (url + "/api/EmployeeManage/CreateEmployeeAsync", contentData);
            string stringJWT = response.Content.
                                   ReadAsStringAsync().Result;
            createEmployeeRM = JsonConvert.DeserializeObject<EmployeeResModel>(stringJWT);

            return createEmployeeRM;
        }
    }
}