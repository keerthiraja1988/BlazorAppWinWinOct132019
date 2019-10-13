using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ResourceModel.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientWebAppBlazor.Infrastructure
{
    public class AppConfiguration
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AppConfiguration(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<bool> LoadAppConfigToStorage()
        {
            List<AppConfigurationValue> items = new List<AppConfigurationValue>();
            List<ApiUrlResModel> apiUrls = new List<ApiUrlResModel>();

            items = await _httpClient.GetJsonAsync<List<AppConfigurationValue>>("sample-data/appsettings.json");

            apiUrls.Add(new ApiUrlResModel { Api = "WebApiAuthenticationServer", ApiUrls = new List<string>() { items.Where(x => x.Key == "WebApiAuthenticationServer").FirstOrDefault().Value } });

            var urls = await _localStorage.GetItemAsync<List<ApiUrlResModel>>("Apis");

            if (urls != null && urls.Count > 0)
            {
                urls = urls.Where(x => x.Api != "WebApiAuthenticationServer").ToList();
                apiUrls.AddRange(urls);
            }
            await _localStorage.RemoveItemAsync("Apis");
            await _localStorage.SetItemAsync("Apis", apiUrls);

            return true;
        }

        public async Task<string> GetApiUrl(string api)
        {
            string url = "";

            var urls = await _localStorage.GetItemAsync<List<ApiUrlResModel>>("Apis");

            if (urls == null || urls.Count == 0)
            {
                await LoadAppConfigToStorage();
                urls = await _localStorage.GetItemAsync<List<ApiUrlResModel>>("Apis");
            }

            return urls.Where(x => x.Api == api).Select(x => x.ApiUrls.FirstOrDefault()).FirstOrDefault();
        }

        public async Task<bool> LoadUrlsToStorage(List<ApiUrlResModel> apiUrls)
        {
            await _localStorage.RemoveItemAsync("Apis");

            List<AppConfigurationValue> items = new List<AppConfigurationValue>();

            items = await _httpClient.GetJsonAsync<List<AppConfigurationValue>>("sample-data/appsettings.json");

            apiUrls.Add(new ApiUrlResModel { Api = "WebApiAuthenticationServer", ApiUrls = new List<string>() { items.Where(x => x.Key == "WebApiAuthenticationServer").FirstOrDefault().Value } });
            await _localStorage.SetItemAsync("Apis", apiUrls);
            return true;
        }
    }

    public class AppConfigurationValue
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}