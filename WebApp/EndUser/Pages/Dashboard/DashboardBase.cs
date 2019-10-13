using Blazorise;
using ClientWebAppBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ResourceModel.Authentication;
using ResourceModel.ClaimsDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAppBlazor.Pages.Dashboard
{
    public class DashboardBase : ComponentBase
    {
        [Inject]
        protected ClaimsADataService _claimsADataService { get; set; }

        [Inject]
        protected AuthenticationDataAccess _authenticationDataAccess { get; set; }

        public JwtToken JwtToken { get; set; } = new JwtToken();

        public ClaimsDashboardDTOResModel ClaimsDashboardDTOResModel { get; set; } = new ClaimsDashboardDTOResModel();

        public async Task OnDashboardLoad()
        {
            JwtToken = await _authenticationDataAccess.GetLoggedInUserDetails();
            ClaimsDashboardDTOResModel.ClaimsACount = await _claimsADataService.GetClaimsCountAsync(JwtToken.UserId);
        }
    }
}
