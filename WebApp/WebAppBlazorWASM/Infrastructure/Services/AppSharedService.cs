using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using ResourceModel.Api;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Security;

namespace WebAppBlazorWASM.Infrastructure.Services
{
    public class AppSharedService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;

        private readonly AppConfigurationService _appConfigurationService;

        public AppSharedService(HttpClient httpClient,
                      AuthenticationStateProvider authenticationStateProvider,
                      ILocalStorageService localStorage, NavigationManager navigationManager
                      , AppConfigurationService appConfigurationService)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            _appConfigurationService = appConfigurationService;
        }

        public async Task<JwtToken> AuthenticateUserAsync(ClientLoginResModel clientLoginResModel)
        {
            JwtToken jwtToken = new JwtToken();
            List<ApiUrlResModel> apiUrls = new List<ApiUrlResModel>();
            string url = await _appConfigurationService.GetApiUrl("WebApiAuthenticationServer");

            string stringData = JsonConvert.SerializeObject(clientLoginResModel);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync
                            (url + "/api/Authentication/AuthenticateUser", contentData);
            string stringJWT = response.Content.ReadAsStringAsync().Result;
            jwtToken = JsonConvert.DeserializeObject<JwtToken>(stringJWT);

            if (jwtToken != null && jwtToken.IsUserAuthenticated)
            {
                await _localStorage.SetItemAsync("authToken", jwtToken.Token);
                await _localStorage.SetItemAsync("signedInSuccessfullyNew", "true");
                await _localStorage.SetItemAsync("signedInSuccessfully", "true");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwtToken.Token);
                await ((AppAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(jwtToken.Token);

                var urls = await _httpClient.GetJsonAsync<List<ApiUrlResModel>>(url + "/api/Authentication/GetApiUrls");
                await _appConfigurationService.LoadUrlsToStorage(urls);
            }
            else
            {
                jwtToken = new JwtToken();
            }

            return jwtToken;
        }
    }
}