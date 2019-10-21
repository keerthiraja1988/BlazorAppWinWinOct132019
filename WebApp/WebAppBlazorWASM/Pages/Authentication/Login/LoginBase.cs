namespace WebAppBlazorWASM.Pages.Authentication.Login
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using ResourceModel.Authentication;
    using WebAppBlazorWASM.Infrastructure.Services;

    public class LoginBase : ComponentBase
    {
        public ClientLoginResModel ClientLoginResModel { get; set; } = new ClientLoginResModel();

        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        public async Task OnAuthenticateUserButtonClick()
        {
            await this._jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");
            JwtToken jwtToken = new JwtToken();
            jwtToken = await this._appSharedService.AuthenticateUserAsync(ClientLoginResModel);

            if (jwtToken == null || !jwtToken.IsUserAuthenticated)
            {
                await this._jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
            }
            else
            {
                this._navigationManager.NavigateTo("");
            }

            await this._jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task HideLoginFailedModel()
        {
        }

        public async Task OnRegisterUserButtonClick()
        {
            await this._jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");
            this._navigationManager.NavigateTo("Register");
        }
    }
}