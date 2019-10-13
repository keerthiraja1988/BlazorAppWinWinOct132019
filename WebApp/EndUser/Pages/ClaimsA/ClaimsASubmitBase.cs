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

            CreateClaimsADTO.CreateClaims.CreatedBy = JwtToken.UserId;

            CreateClaimsADTO.ClaimId = await _claimsADataService.GetOpenClaimIdAsync(JwtToken.UserId);

            if (CreateClaimsADTO.ClaimId > 0)
            {
                CreateClaimsADTO.CreateClaims.ClaimId = CreateClaimsADTO.ClaimId;
            }
        }

        public async Task OnCreateClaimAButtonClick()
        {
            var claimAItemid = await _claimsADataService.CreateClaimAAsync(CreateClaimsADTO.CreateClaims);
            Console.WriteLine("OnCreateClaimAButtonClick" + claimAItemid);
            if (claimAItemid > 0)
            {
                CreateClaimsADTO = new CreateClaimsADTOResModel();
                CreateClaimsADTO.CreateClaims.CreatedBy = JwtToken.UserId;
                CreateClaimsADTO.ClaimId = await _claimsADataService.GetOpenClaimIdAsync(JwtToken.UserId);
                if (CreateClaimsADTO.ClaimId > 0)
                {
                    CreateClaimsADTO.CreateClaims.ClaimId = CreateClaimsADTO.ClaimId;
                }
            }
        }

        public async Task OnAddClaimAClearButtonClick()
        {
            CreateClaimsADTO = new CreateClaimsADTOResModel();
        }
    }
}