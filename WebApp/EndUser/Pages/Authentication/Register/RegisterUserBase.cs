using Blazorise;
using ClientWebAppBlazor.Services;
using Microsoft.AspNetCore.Components;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientWebAppBlazor.Pages.Authentication.Register
{
    public class RegisterUserBase : ComponentBase
    {
        [Inject]
        protected AuthenticationDataAccess _authenticationDataAccess { get; set; }

        public RegisterUserResModel RegisterUser { get; set; } = new RegisterUserResModel();
        public Modal ModalRef { get; set; } = new Modal();


        public async Task OnRegisterUserButtonClick()
        {
            UserDetailResModel userDetailRM = new UserDetailResModel();

            userDetailRM = await this._authenticationDataAccess.RegisterUserAsync(RegisterUser);

            if (userDetailRM.UserId > 0)
            {
                ModalRef.Show();
            }

            Console.WriteLine("OnValidSubmit");
        }

        public async Task HideModal()
        {
            ModalRef.Hide();
        }
    }
}
