using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBlazorWASM.Infrastructure.Services;

namespace WebAppBlazorWASM.Pages.Authentication.Register
{
    public class RegisterUserBase : ComponentBase
    {
        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        public RegisterUserResModel RegisterUser { get; set; } = new RegisterUserResModel();

        public async Task OnRegisterUserButtonClick()
        {
            await _jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");

            UserDetailResModel userDetailRM = new UserDetailResModel();

            userDetailRM = await this._appSharedService.RegisterUserAsync(RegisterUser);

            if (userDetailRM.UserId > 0)
            {
                await _jsRuntime.InvokeVoidAsync("homeController.showAlert", "User created sucessfully. Login to application.");
                _navigationManager.NavigateTo("Login");
            }
            else
            {
                await _jsRuntime.InvokeVoidAsync("homeController.showAlert", "Unale to create new user. Please try again");
                await _jsRuntime.InvokeVoidAsync("homeController.reloadPage", "");
            }

            await _jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task OnLoginUserButtonClick()
        {
            await _jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");
            _navigationManager.NavigateTo("Login");
        }
    }
}