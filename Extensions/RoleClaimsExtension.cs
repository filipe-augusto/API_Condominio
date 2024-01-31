using API_Condominio.Models;
using System.Security.Claims;

namespace API_Condominio.Extensions;

    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {


            var result = new List<Claim>() {
                    new(ClaimTypes.Name, user.Email)};
            result.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Slug)));

            return result;
        }
    }
