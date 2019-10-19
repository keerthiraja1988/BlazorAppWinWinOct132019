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
using ResourceModel.ClaimsA.Create;

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

            return 123;
        }

        public async Task<Int64> GetOpenClaimIdAsync(Int64 userId)
        {
            Int64 claimAId = 0;
            string url = await _appConfiguration.GetApiUrl("ClaimsAServer");

            claimAId = await _httpClient.GetJsonAsync<Int64>(url + "/api/ClaimsA/GetOpenClaimIdAsync" + "?userId=" + userId);
            return claimAId;
        }

        public async Task<Int64> CreateClaimAAsync(CreateClaimsAResModel createClaimsA)
        {
            string url = await _appConfiguration.GetApiUrl("ClaimsAServer");
            Int64 claimsAItemId = 0;

            string stringData = JsonConvert.SerializeObject(createClaimsA);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync
                           (url + "/api/ClaimsA/CreateClaimAAsync", contentData);
            string stringJWT = response.Content.ReadAsStringAsync().Result;
            claimsAItemId = JsonConvert.DeserializeObject<Int64>(stringJWT);

            Console.WriteLine("CreateClaimAAsync" + claimsAItemId);

            return claimsAItemId;
        }

        public async Task<List<CreateClaimsAResModel>> GetClaimItemsAsync(Int64 claimAId)
        {
            List<CreateClaimsAResModel> createClaimAs = new List<CreateClaimsAResModel>();

            string url = await _appConfiguration.GetApiUrl("ClaimsAServer");

            createClaimAs = await _httpClient.GetJsonAsync<List<CreateClaimsAResModel>>(url + "/api/ClaimsA/GetClaimItemsAsync" + "?claimAId=" + claimAId);

            return createClaimAs;
        }

        public async Task DeleteClaimItemsAsync(Int64 claimItemId)
        {
            string url = await _appConfiguration.GetApiUrl("ClaimsAServer");

            await _httpClient.DeleteAsync(url + "/api/ClaimsA/DeleteClaimItemsAsync" + "?claimItemid=" + claimItemId);
        }
    }
}