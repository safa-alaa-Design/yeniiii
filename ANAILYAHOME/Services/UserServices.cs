using System.Security.Claims;
using ANAILYAHOME.entityes;
using ANAILYAHOME.Models;

namespace ANAILYAHOME.Services
{
    public static class UserServices
    {
        public static int GetSaticiId(this ClaimsPrincipal user)
        {
            var claim = user.Claims.FirstOrDefault(i => i.Type == ClaimTypesadmin.SaticiId)?.Value;
            if (claim != null)
            {
                return Convert.ToInt16(claim);
            }
            return 0;
        }

        public static List<katagore>? GetKategoriler(this ClaimsPrincipal user)
        {
            var claim = user.Claims.FirstOrDefault(i => i.Type == ClaimTypesadmin.Kategoriler)?.Value;
            if (claim != null)
            {
                var list = claim.Split("&&");
                return list.Select(i => (katagore)Convert.ToInt16(i)).ToList();
            }
            return null;
        }
    }
}
