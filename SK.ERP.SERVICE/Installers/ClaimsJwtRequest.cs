using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SK.ERP.SERVICE.Installers
{
    public class ClaimsJwtRequest : ControllerBase
    {
        public int GetUserIdbyJwt()
        {
            string accessToken = User.FindFirst("access_token")?.Value;
            //string accessToken = HttpContext.User.Claims.First(c => c.Type == "code").Value;

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(accessToken);
            var tokenS = handler.ReadJwtToken(accessToken) as JwtSecurityToken;

            var UserId = tokenS.Claims.First(claim => claim.Type == "code").Value;
            var USUARIO_NAME = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.UniqueName).Value;
            var Token_Expired = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Exp).Value;
            var Roles = new List<string>();
            foreach (var claim in tokenS.Claims)
            {
                if (claim.Type == "role")
                {
                    Roles.Add(claim.Value);
                }
            }

            return Convert.ToInt32(UserId);
        }
    }
}
