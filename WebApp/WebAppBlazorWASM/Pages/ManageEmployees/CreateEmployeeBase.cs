using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Services;

namespace WebAppBlazorWASM.Pages.ManageEmployees
{
    public class CreateEmployeeBase : ComponentBase
    {
        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        public JwtToken jwtToken { get; set; } = new JwtToken();

        public async Task OnCreateEmployeeLoad()
        {
            jwtToken = await _appSharedService.GetLoggedInUserDetails();
        }
    }
}