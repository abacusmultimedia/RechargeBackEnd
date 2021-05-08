using CommonLayer.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using static CommonLayer.Constants;

namespace CommonLayer.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<LookupDTO> ToCustomLookup(this IEnumerable<ILookUps> entity)
        {
            return entity.Select(p => new DTOs.LookupDTO() { Key = p.Id, Value = p.Name });
        }

        public static string GetRole(this ClaimsPrincipal principal)
        {
            return principal.Claims.ToList().FirstOrDefault(x => x.Type.Trim() == CustomClaims.Role).Value;
        }

        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.Claims.ToList().FirstOrDefault(x => x.Type.Trim() == CustomClaims.UserId).Value;
        }
    }
}
