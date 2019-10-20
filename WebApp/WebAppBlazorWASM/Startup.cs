using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebAppBlazorWASM.Infrastructure.Security;
using WebAppBlazorWASM.Infrastructure.Services;
using WebAppBlazorWASM.Services;

namespace WebAppBlazorWASM
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true; // optional
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddSingleton<AuthenticationStateProvider, AppAuthenticationStateProvider>();

            services.AddSingleton<AppSharedService>();
            services.AddSingleton<AppConfigurationService>();
            services.AddSingleton<EmployeeManageService>();
            services.AddSingleton<EmployeeApprovalService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();
            app.AddComponent<App>("app");
        }
    }
}