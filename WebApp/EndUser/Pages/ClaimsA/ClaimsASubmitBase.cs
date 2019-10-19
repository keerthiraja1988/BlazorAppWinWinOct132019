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
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected ClaimsADataService _claimsADataService { get; set; }

        [Inject]
        protected AuthenticationDataAccess _authenticationDataAccess { get; set; }

        public JwtToken JwtToken { get; set; } = new JwtToken();

        public CreateClaimsADTOResModel CreateClaimsADTO { get; set; } = new CreateClaimsADTOResModel();

        public List<CreateClaimsAResModel> ClaimsAdded { get; set; } = new List<CreateClaimsAResModel>();

        public async Task OnDashboardLoad()
        {
            await JsRuntime.InvokeVoidAsync("homeController.loadClaimsAController", "");
            JwtToken = await _authenticationDataAccess.GetLoggedInUserDetails();

            CreateClaimsADTO.CreateClaims.CreatedBy = JwtToken.UserId;

            CreateClaimsADTO.ClaimId = await _claimsADataService.GetOpenClaimIdAsync(JwtToken.UserId);

            if (CreateClaimsADTO.ClaimId > 0)
            {
                CreateClaimsADTO.CreateClaims.ClaimId = CreateClaimsADTO.ClaimId;
                await LoadClaimAItems();
            }
        }

        public async Task OnCreateClaimAButtonClick()
        {
            await JsRuntime.InvokeVoidAsync("homeController.showLoadingIndicator", "");

            if (CreateClaimsADTO.ClaimId == 0)
            {
                CreateClaimsADTO.ClaimId = await _claimsADataService.GetOpenClaimIdAsync(JwtToken.UserId);

                if (CreateClaimsADTO.ClaimId > 0)
                {
                    CreateClaimsADTO.CreateClaims.ClaimId = CreateClaimsADTO.ClaimId;
                }
            }

            var claimAItemid = await _claimsADataService.CreateClaimAAsync(CreateClaimsADTO.CreateClaims);

            if (claimAItemid > 0)
            {
                CreateClaimsADTO = new CreateClaimsADTOResModel();
                CreateClaimsADTO.CreateClaims.CreatedBy = JwtToken.UserId;

                CreateClaimsADTO.ClaimId = await _claimsADataService.GetOpenClaimIdAsync(JwtToken.UserId);
                if (CreateClaimsADTO.ClaimId > 0)
                {
                    CreateClaimsADTO.CreateClaims.ClaimId = CreateClaimsADTO.ClaimId;
                }

                await JsRuntime.InvokeVoidAsync("claimsAController.claimsItemAddedSuccessfully", "");
                await LoadClaimAItems();
            }

            await JsRuntime.InvokeVoidAsync("homeController.hideLoadingIndicator", "");
        }

        public async Task LoadClaimAItems()
        {
            ClaimsAdded = await _claimsADataService.GetClaimItemsAsync(CreateClaimsADTO.ClaimId);
        }

        public async Task OnAddClaimAClearButtonClick()
        {
            CreateClaimsADTO = new CreateClaimsADTOResModel();
        }
    }
}