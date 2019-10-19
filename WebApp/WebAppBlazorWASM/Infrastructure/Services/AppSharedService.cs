using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
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
        private readonly IJSRuntime _jsRuntime;
        private readonly AppConfigurationService _appConfigurationService;

        public AppSharedService(HttpClient httpClient,
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

        public async Task<UserDetailResModel> RegisterUserAsync(RegisterUserResModel registerUser)
        {
            UserDetailResModel userDetailResModel = new UserDetailResModel();

            string url = await _appConfigurationService.GetApiUrl("WebApiAuthenticationServer");

            string stringData = JsonConvert.SerializeObject(registerUser);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync
                            (url + "/api/Authentication/RegisterUserAsync", contentData);
            string stringJWT = response.Content.
                                   ReadAsStringAsync().Result;
            userDetailResModel = JsonConvert.DeserializeObject<UserDetailResModel>(stringJWT);

            return userDetailResModel;
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
                await _localStorage.SetItemAsync("signedInSuccessfullyFlag", "true");
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

        public async Task LogoutUser()
        {
            await _localStorage.ClearAsync();
            await _localStorage.SetItemAsync("loggedOutSuccessfullyFlag", "true");
            await ((AppAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        }

        public async Task<JwtToken> GetLoggedInUserDetails()
        {
            bool isUserAuthenticated = false;
            JwtToken jwtToken = new JwtToken();
            try
            {
                string url = await _appConfigurationService.GetApiUrl("WebApiAuthenticationServer");

                AuthenticationState authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();

                HttpResponseMessage response = await _httpClient.GetAsync(url + "/api/Authentication/ValidateUserAuthentication");
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                isUserAuthenticated = JsonConvert.DeserializeObject<bool>(stringJWT);

                jwtToken = await ((AppAuthenticationStateProvider)_authenticationStateProvider).GetLoggedInUserDetails();
                jwtToken.IsUserAuthenticated = isUserAuthenticated;
            }
            catch (Exception)
            {
                await LogoutUser();
                await _jsRuntime.InvokeVoidAsync("homeController.redirectToPage", "Login");
            }

            return jwtToken;
        }
    }
}