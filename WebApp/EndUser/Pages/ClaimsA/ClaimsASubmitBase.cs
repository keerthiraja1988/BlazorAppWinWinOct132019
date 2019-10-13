using Blazorise;
using ClientWebAppBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using ResourceModel.ClaimsA.Create;
using ResourceModel.ClaimsDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAppBlazor.Pages.ClaimsA
{
    public class ClaimsASubmitBase : ComponentBase
    {
        [Inject]
        protected ClaimsADataService _claimsADataService { get; set; }

        [Inject]
        protected AuthenticationDataAccess _authenticationDataAccess { get; set; }

        public JwtToken JwtToken { get; set; } = new JwtToken();

        public CreateClaimsADTOResModel CreateClaimsADTO { get; set; } = new CreateClaimsADTOResModel();

        public async Task OnDashboardLoad()
        {
            JwtToken = await _authenticationDataAccess.GetLoggedInUserDetails();
        }

        public async Task OnCreateClaimAButtonClick()
        {
        }
    }
}