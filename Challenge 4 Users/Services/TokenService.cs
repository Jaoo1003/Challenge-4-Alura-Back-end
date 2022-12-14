using Challenge_4_Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Challenge_4_Users.Services {
    public class TokenService {

        public Token CreateToken(IdentityUser<int> user, string role) {
            Claim[] userClaims = new Claim[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aseo2sef@53hd!3673fgdj!3@%$¨T#WEGhergaihzsef#@%$@3rGasrgaise!gisehf%ufy@"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims:userClaims,
                signingCredentials:credentials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }
    }
}
