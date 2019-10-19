using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Services;

namespace WebAppBlazorWASM.Pages.Authentication.Login
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        public ClientLoginResModel ClientLoginResModel { get; set; } = new ClientLoginResModel();

        public async Task OnAuthenticateUserButtonClick()
        {
            await _jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");
            JwtToken jwtToken = new JwtToken();
            jwtToken = await this._appSharedService.AuthenticateUserAsync(ClientLoginResModel);

            if (jwtToken == null || !jwtToken.IsUserAuthenticated)
            {
                await _jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
            }
            else
            {
                _navigationManager.NavigateTo("");
            }

            await _jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task HideLoginFailedModel()
        {
        }

        public async Task OnRegisterUserButtonClick()
        {
            await _jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");
            _navigationManager.NavigateTo("Register");
        }
    }
}