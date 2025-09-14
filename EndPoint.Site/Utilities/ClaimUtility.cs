using System.Security.Claims;

namespace EndPoint.Site.Utilities
{
    public static class ClaimUtility
    {
        public static long? GetUserID(ClaimsPrincipal user)
        {
            try
            {
                var claim = user.FindFirst(ClaimTypes.NameIdentifier);
                if (claim != null && long.TryParse(claim.Value, out long userId))
                {
                    return userId;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
