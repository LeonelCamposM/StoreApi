using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StorePresentation;
using StorePresentation.Infrastructure;
using System.Security.Claims;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://StoreApicr.onmicrosoft.com/cb131417-eaa3-430b-8643-f46e44bf1b1c/Api.ReadWrite");
    options.UserOptions.RoleClaim = ClaimTypes.Role;
}).AddAccountClaimsPrincipalFactory<AzureADB2CUserFactory>();

await builder.Build().RunAsync();
