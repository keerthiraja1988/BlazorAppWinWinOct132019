using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Services;

namespace WebAppBlazorWASM.Pages.Dashboard
{
    public class DashboardBase : ComponentBase
    {
        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        public JwtToken jwtToken { get; set; } = new JwtToken();

        public async Task OnDashboardLoad()
        {
            jwtToken = await _appSharedService.GetLoggedInUserDetails();

            if (await _localStorage.GetItemAsync<string>("signedInSuccessfullyFlag") == "true")
            {
                await _jsRuntime.InvokeVoidAsync("homeController.showSuccessToastNotification", "Logged in successfully");
                await _localStorage.RemoveItemAsync("signedInSuccessfullyFlag");
            }
        }
    }
}