namespace WebAppBlazorWASM.Pages.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebAppBlazorWASM.Infrastructure.Services;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using ResourceModel.Authentication;

    public class DashboardBase : ComponentBase
    {
        public JwtToken JwtTokent { get; set; } = new JwtToken();

        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        public async Task OnDashboardLoad()
        {
            if (await this._localStorage.GetItemAsync<string>("signedInSuccessfullyFlag") == "true")
            {
                await this._jsRuntime.InvokeVoidAsync("homeController.showSuccessToastNotification", "Logged in successfully");
                await this._localStorage.RemoveItemAsync("signedInSuccessfullyFlag");
            }
        }
    }
}