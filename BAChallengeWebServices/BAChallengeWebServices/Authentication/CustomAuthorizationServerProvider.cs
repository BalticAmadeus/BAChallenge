using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BAChallengeWebServices.Authentication
{
    /// <summary>
    /// Custom ServerProvider, which changes some parts to work with identity framweork.
    /// </summary>
    public class CustomAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run((()=>context.Validated()));
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var authorization = new AuthorisationRepository())
            {
                var user = await authorization.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The username or password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            }
        }
    }
}