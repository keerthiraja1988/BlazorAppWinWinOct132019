namespace WebAppBlazorWASM.Pages.Authentication.Register
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using ResourceModel.Authentication;
    using WebAppBlazorWASM.Infrastructure.Services;

    public class RegisterUserBase : ComponentBase
    {
        public RegisterUserResModel RegisterUser { get; set; } = new RegisterUserResModel();

        [Inject]
        protected AppSharedService _appSharedService { get; set; }

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        public async Task OnRegisterUserButtonClick()
        {
            await this._jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");

            UserDetailResModel userDetailRM = new UserDetailResModel();

            userDetailRM = await this._appSharedService.RegisterUserAsync(this.RegisterUser);

            if (userDetailRM.UserId > 0)
            {
                await this._jsRuntime.InvokeVoidAsync("homeController.showAlert", "User created sucessfully. Login to application.");
                this._navigationManager.NavigateTo("Login");
            }
            else
            {
                await this._jsRuntime.InvokeVoidAsync("homeController.showAlert", "Unale to create new user. Please try again");
                await this._jsRuntime.InvokeVoidAsync("homeController.reloadPage", "");
            }

            await this._jsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task OnLoginUserButtonClick()
        {
            await this._jsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");
            this._navigationManager.NavigateTo("Login");
        }
    }
}