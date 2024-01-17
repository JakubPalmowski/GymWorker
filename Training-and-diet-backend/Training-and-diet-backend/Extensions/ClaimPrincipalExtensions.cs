using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Training_and_diet_backend.Extensions
{
    public static class ClaimPrincipalExtensions 
    {
        public static int? GetId(this ClaimsPrincipal claimPrincipal)
        {
            var idAppUser = claimPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var canParse = int.TryParse(idAppUser, out var parsedIdAppUser);
            if (!canParse)
                return null;
            return parsedIdAppUser;
        }
    }
}
