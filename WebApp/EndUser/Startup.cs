using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ClientWebAppBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ClientWebAppBlazor.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace ClientWebAppBlazor
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
            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

            services.AddSingleton<AuthenticationDataAccess>();
            services.AddSingleton<ClaimsADataService>();
            services.AddSingleton<AppConfiguration>();
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
