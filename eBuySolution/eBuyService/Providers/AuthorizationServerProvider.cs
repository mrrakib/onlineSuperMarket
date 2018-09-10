
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;
using eBuyService.Models;

namespace eBuyService.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            eBuyContext db = new eBuyContext(); 

            var user = db.UserDetails.Where(d => d.UserEmail == context.UserName).FirstOrDefault();
            if (user != null && !string.IsNullOrEmpty(user.UserEmail) && !string.IsNullOrEmpty(user.UserPassword))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                if (context.UserName == user.UserEmail && context.Password == user.UserPassword)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole));
                    identity.AddClaim(new Claim("username", user.UserEmail));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                    var uid = new Dictionary<string, string>() { { "userid", user.UserId.ToString() }, { "role", user.UserRole.ToString() } };

                    var ticket = new AuthenticationTicket(identity, new AuthenticationProperties(uid));

                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "Username and Password Combination Provided is Incorrect!");
                    return;
                }
            }
        }

    }
}