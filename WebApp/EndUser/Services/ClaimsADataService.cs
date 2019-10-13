using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using ClientWebAppBlazor.Infrastructure;
using ResourceModel.Api;

namespace ClientWebAppBlazor.Services
{
    public class ClaimsADataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly AppConfiguration _appConfiguration;
        private readonly NavigationManager NavigationManager;

        public ClaimsADataService(HttpClient httpClient,
                      AuthenticationStateProvider authenticationStateProvider,
                      ILocalStorageService localStorage, AppConfiguration appConfiguration, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _appConfiguration = appConfiguration;
        }

        public async Task<Int64> GetClaimsCountAsync(Int64 userId)
        {
            Int64 claimsACount = 0;

            string url = await _appConfiguration.GetApiUrl("ClaimsAServer");

            claimsACount = await _httpClient.GetJsonAsync<Int64>(url + "/api/ClaimsA/GetClaimsCountAsync" + "?userId=" + userId);
            //string stringJWT = response.Content.ReadAsStringAsync().Result;
            //claimsACount = JsonConvert.DeserializeObject<Int64>(stringJWT);
           
            return 123;
        }
    }

}
