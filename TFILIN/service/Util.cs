using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public static class Util
    {
        //public static int ExtractUserIdFromToken(string token)
        //{
        //    var handler = new JwtSecurityTokenHandler();
        //    var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
        //    var userId = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == "unique_name")?.Value;
        //    if (userId == null)
        //    {
        //        throw new InvalidOperationException("User ID claim not found in the token.");
        //    }
        //    return int.Parse(userId);
        //}
    }
}
