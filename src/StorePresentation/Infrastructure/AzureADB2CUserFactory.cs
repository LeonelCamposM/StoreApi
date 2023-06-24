using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.IdentityModel.Tokens.Jwt;
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
            if (initialUser.Identity.IsAuthenticated)
            {
                string token_str = "";
                string role = "";
                var tokenResult = await TokenProvider.RequestAccessToken();
                if (tokenResult.TryGetToken(out var token))
                {
                    token_str = token.Value;
                    role = GetUserRole(token_str);
                }
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }
            return initialUser;
        }

        private string GetUserRole(string token_str)
        {
            var role = "";
            if (token_str != "")
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(token_str);
                var userName = token.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value;
                role = token.Claims.FirstOrDefault(c => c.Type == "extension_role")?.Value;
            }
            return role;
        }
    }
}
