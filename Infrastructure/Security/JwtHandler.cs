using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;

namespace CrudLeads.Infrastructure.Security
{
    public class JwtHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.RequestUri != null && request.RequestUri.AbsolutePath.IndexOf("/login", StringComparison.OrdinalIgnoreCase) >= 0
                && request.Method == HttpMethod.Post)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            const string scheme = "Bearer ";
            var authHeader = request.Headers.Authorization;
            if (authHeader == null || !authHeader.Scheme.Equals("Bearer", StringComparison.OrdinalIgnoreCase)
                || string.IsNullOrWhiteSpace(authHeader.Parameter))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var token = authHeader.Parameter.Trim();
            try
            {
                var principal = ValidateToken(token);
                if (principal != null)
                {
                    request.GetRequestContext().Principal = principal;
                    Thread.CurrentPrincipal = principal;
                }
            }
            catch
            {
                return request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid or expired token");
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private static IPrincipal ValidateToken(string token)
        {
            var secret = ConfigurationManager.AppSettings["JwtSecret"] ?? "CrudLeadsJwtSecretKeyMustBeAtLeast32CharactersLong!";
            var issuer = ConfigurationManager.AppSettings["JwtIssuer"] ?? "CrudLeads";
            var audience = ConfigurationManager.AppSettings["JwtAudience"] ?? "CrudLeadsApi";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var validationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(token, validationParams, out _);
            return principal;
        }
    }
}
