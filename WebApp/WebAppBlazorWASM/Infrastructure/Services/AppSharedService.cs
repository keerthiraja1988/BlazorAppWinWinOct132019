namespace WebAppBlazorWASM.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Newtonsoft.Json;
    using ResourceModel.Api;
    using ResourceModel.Authentication;
    using WebAppBlazorWASM.Infrastructure.Security;

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
                      , IJSRuntime ijsRuntime)
        {
            this._httpClient = httpClient;
            this._authenticationStateProvider = authenticationStateProvider;
            this._localStorage = localStorage;
            this._navigationManager = navigationManager;
            this._appConfigurationService = appConfigurationService;
            this._jsRuntime = ijsRuntime;
        }

        public async Task<UserDetailResModel> RegisterUserAsync(RegisterUserResModel registerUser)
        {
            UserDetailResModel userDetailResModel = new UserDetailResModel();

            string url = await this._appConfigurationService.GetApiUrl("WebApiAuthenticationServer");

            string stringData = JsonConvert.SerializeObject(registerUser);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this._httpClient.PostAsync
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
            string url = await this._appConfigurationService.GetApiUrl("WebApiAuthenticationServer");

            string stringData = JsonConvert.SerializeObject(clientLoginResModel);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this._httpClient.PostAsync
                            (url + "/api/Authentication/AuthenticateUser", contentData);
            string stringJWT = response.Content.ReadAsStringAsync().Result;
            jwtToken = JsonConvert.DeserializeObject<JwtToken>(stringJWT);

            if (jwtToken != null && jwtToken.IsUserAuthenticated)
            {
                await this._localStorage.SetItemAsync("authToken", jwtToken.Token);
                await this._localStorage.SetItemAsync("signedInSuccessfullyFlag", "true");
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwtToken.Token);
                await ((AppAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsAuthenticated(jwtToken.Token);

                var urls = await this._httpClient.GetJsonAsync<List<ApiUrlResModel>>(url + "/api/Authentication/GetApiUrls");
                await this._appConfigurationService.LoadUrlsToStorage(urls);
            }
            else
            {
                jwtToken = new JwtToken();
            }

            return jwtToken;
        }

        public async Task LogoutUser()
        {
            await this._localStorage.ClearAsync();

            await ((AppAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsLoggedOut();
        }

        public async Task<JwtToken> GetLoggedInUserDetails()
        {
            bool isUserAuthenticated = false;
            JwtToken jwtToken = new JwtToken();
            try
            {
                string url = await this._appConfigurationService.GetApiUrl("WebApiAuthenticationServer");

                AuthenticationState authenticationState = await this._authenticationStateProvider.GetAuthenticationStateAsync();

                HttpResponseMessage response = await this._httpClient.GetAsync(url + "/api/Authentication/ValidateUserAuthentication");
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                isUserAuthenticated = JsonConvert.DeserializeObject<bool>(stringJWT);

                jwtToken = await ((AppAuthenticationStateProvider)this._authenticationStateProvider).GetLoggedInUserDetails();
                jwtToken.IsUserAuthenticated = isUserAuthenticated;
            }
            catch (Exception)
            {
                await this.LogoutUser();
                await this._jsRuntime.InvokeVoidAsync("homeController.redirectToPage", "Login");
            }

            return jwtToken;
        }
    }
}