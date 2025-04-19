using System.Security.Claims;
using System.Security.Principal;

namespace CleanArch.Store.Application.Extention
{
    public static class UserExtentions
    {
        public static string GetUserId(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;

            return user.GetUserId();
        }
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
                if (data != null) return data.Value;

            }

            return "";
        }
    }
}
