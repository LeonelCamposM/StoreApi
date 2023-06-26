using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using StorePresentation.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace StorePresentation.Infrastructure
{
    public class AzureADB2CUserFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {

        public AzureADB2CUserFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
        {
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options){
            var initialUser = await base.CreateUserAsync(account, options);
            var userIdentity = initialUser.Identity as ClaimsIdentity;
            if (initialUser.Identity!.IsAuthenticated)
            {
                string role = "";
                var tokenResult = await TokenProvider.RequestAccessToken();
                if (tokenResult.TryGetToken(out var token))
                {
                    var result = role = GetUserRole(token.Value);
                }
                userIdentity!.AddClaim(new Claim(ClaimTypes.Role, role));
            }
            return initialUser;
        }

        private string GetUserRole(string token_str)
        {
            var role = "";
            var userName = "";
            if (token_str != "")
            {
                var handler = new JwtSecurityTokenHandler();
                GlobalVariables.SetUserToken(token_str);
                var token = handler.ReadJwtToken(token_str);
                userName = token.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value;
                GlobalVariables.SetUserName(userName!);
                var emails = token.Claims.FirstOrDefault(c => c.Type == "emails")?.Value;
                GlobalVariables.SetUserEmail(emails!);
                role = token.Claims.FirstOrDefault(c => c.Type == "extension_role")?.Value;
            }
            return role!;
        }
    }
}
