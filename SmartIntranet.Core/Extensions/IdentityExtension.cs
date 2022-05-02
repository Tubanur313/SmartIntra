using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SmartIntranet.Core.Extensions
{
    static public partial class IdentityExtension
    {
        static public string ClaimValue(this ClaimsPrincipal principal, string name)
        {
            return principal.Claims.FirstOrDefault(c => c.Type.Equals(name))?.Value;
        }
        static public int? GetPrincipalId(this ClaimsPrincipal principal)
        {
            var idData = principal.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            if (idData == null)
                return null;

            return Convert.ToInt32(idData);


        }
        static public int? GetPrincipalId(this IActionContextAccessor ctx)
        {
            var idData = ctx.ActionContext.HttpContext.User
                .Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            if (idData == null)
                return null;

            return Convert.ToInt32(idData);


        }


        static public bool HasAccess(this ClaimsPrincipal principal, string claimName)
        {
            return principal.HasClaim(c => c.Type.Equals(claimName) && c.Value.Equals("1"))
                || principal.IsInRole("SuperAdmin")
                ;
        }
    }
}
