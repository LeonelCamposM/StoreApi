using System.Security.Claims;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace StoreAPI.Middlewares
{
    public class IdentityMiddleware
    {
        private readonly RequestDelegate _next;

        public IdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var identity = context.User.Identity as ClaimsIdentity;
                var myClaim = identity.Claims.FirstOrDefault(c => c.Type == "extension_role");
                context.User.AddIdentity(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, myClaim.Value) }));
            }

            await _next(context);
        }
    }
}
