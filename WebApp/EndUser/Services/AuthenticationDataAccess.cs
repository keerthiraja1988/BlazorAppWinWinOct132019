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
    public class AuthenticationDataAccess
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly AppConfiguration _appConfiguration;
        private readonly NavigationManager NavigationManager;

        public AuthenticationDataAccess(HttpClient httpClient,
                      AuthenticationStateProvider authenticationStateProvider,
                      ILocalStorageService localStorage, AppConfiguration appConfiguration, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _appConfiguration = appConfiguration;
            NavigationManager = navigationManager;

        }

        public async Task<UserDetailResModel> RegisterUserAsync(RegisterUserResModel registerUser)
        {
            UserDetailResModel userDetailResModel = new UserDetailResModel();

            string url = await _appConfiguration.GetApiUrl("WebApiAuthenticationServer");

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
            string url = await _appConfiguration.GetApiUrl("WebApiAuthenticationServer");

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
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(jwtToken.Token);

                var urls = await _httpClient.GetJsonAsync<List<ApiUrlResModel>>(url + "/api/Authentication/GetApiUrls");
                await _appConfiguration.LoadUrlsToStorage(urls);
            }
            else
            {
                jwtToken = new JwtToken();
            }

            return jwtToken;
        }

        public async Task<JwtToken> GetLoggedInUserDetails()
        {
            bool isUserAuthenticated = false;
            JwtToken jwtToken = new JwtToken();
            try
            {
                string url = await _appConfiguration.GetApiUrl("WebApiAuthenticationServer");

                AuthenticationState authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();

                HttpResponseMessage response = await _httpClient.GetAsync(url + "/api/Authentication/ValidateUserAuthentication");
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                isUserAuthenticated = JsonConvert.DeserializeObject<bool>(stringJWT);

                jwtToken = await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetLoggedInUserDetails();
                jwtToken.IsUserAuthenticated = isUserAuthenticated;
            }
            catch (Exception)
            {
                NavigationManager.NavigateTo("Login");
            }

            return jwtToken;
        }
        public async Task LogoutUser()
        {
            await _localStorage.ClearAsync();
            await _localStorage.SetItemAsync("loggedOutSuccessfully", "true");
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        }

        public async Task<JwtToken> GetLoggedInUserDetails1()
        {
            JwtToken jwtToken = new JwtToken();
            jwtToken = await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetLoggedInUserDetails();
            return jwtToken;
        }
    }

}
