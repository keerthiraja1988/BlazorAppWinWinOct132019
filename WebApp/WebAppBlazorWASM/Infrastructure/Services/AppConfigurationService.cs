namespace WebAppBlazorWASM.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components;
    using ResourceModel.Api;

    public class AppConfigurationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AppConfigurationService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            this._httpClient = httpClient;
            this._localStorage = localStorage;
        }

        public async Task<bool> LoadAppConfigToStorage()
        {
            List<AppConfigurationValue> items = new List<AppConfigurationValue>();
            List<ApiUrlResModel> apiUrls = new List<ApiUrlResModel>();

            await this._localStorage.RemoveItemAsync("Apis");

            items = await this._httpClient.GetJsonAsync<List<AppConfigurationValue>>("sample-data/appsettings.json");

            apiUrls.Add(new ApiUrlResModel { Api = "WebApiAuthenticationServer", ApiUrls = new List<string>() { items.Where(x => x.Key == "WebApiAuthenticationServer").FirstOrDefault().Value } });

            var urls = await this._localStorage.GetItemAsync<List<ApiUrlResModel>>("Apis");

            if (urls != null && urls.Count > 0)
            {
                urls = urls.Where(x => x.Api != "WebApiAuthenticationServer").ToList();
                apiUrls.AddRange(urls);
            }

            await this._localStorage.SetItemAsync("Apis", apiUrls);

            return true;
        }

        public async Task<string> GetApiUrl(string api)
        {
            string url = "";

            var urls = await this._localStorage.GetItemAsync<List<ApiUrlResModel>>("Apis");

            if (urls == null || urls.Count == 0)
            {
                await this.LoadAppConfigToStorage();
                urls = await this._localStorage.GetItemAsync<List<ApiUrlResModel>>("Apis");
            }

            return urls.Where(x => x.Api == api).Select(x => x.ApiUrls.FirstOrDefault()).FirstOrDefault();
        }

        public async Task<bool> LoadUrlsToStorage(List<ApiUrlResModel> apiUrls)
        {
            await this._localStorage.RemoveItemAsync("Apis");

            List<AppConfigurationValue> items = new List<AppConfigurationValue>();

            items = await this._httpClient.GetJsonAsync<List<AppConfigurationValue>>("sample-data/appsettings.json");

            apiUrls.Add(new ApiUrlResModel { Api = "WebApiAuthenticationServer", ApiUrls = new List<string>() { items.Where(x => x.Key == "WebApiAuthenticationServer").FirstOrDefault().Value } });
            await this._localStorage.SetItemAsync("Apis", apiUrls);
            return true;
        }

        public class AppConfigurationValue
        {
            public string Key { get; set; }

            public string Value { get; set; }
        }
    }
}