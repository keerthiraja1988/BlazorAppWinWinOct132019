using Blazorise;
using ClientWebAppBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAppBlazor.Pages.Login
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        protected AuthenticationDataAccess _authenticationDataAccess { get; set; }

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        public ClientLoginResModel ClientLoginResModel { get; set; } = new ClientLoginResModel();

        public Modal LoginFailedModel { get; set; } = new Modal() ;

        public async Task OnAuthenticateUserButtonClick()
        {
            JwtToken jwtToken = new JwtToken();
            jwtToken = await this._authenticationDataAccess.AuthenticateUserAsync(ClientLoginResModel);

            if (jwtToken == null || !jwtToken.IsUserAuthenticated)
            {
                LoginFailedModel.Show();
            }
            else
            {
                _navigationManager.NavigateTo("");
            }
        }

        public async Task HideLoginFailedModel()
        {

            LoginFailedModel.Hide();
        }

        public async Task OnRegisterUserButtonClick()
        {
            _navigationManager.NavigateTo("Register");
        }
    }
}
