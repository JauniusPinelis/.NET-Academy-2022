using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StaffManagement.Services.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StaffManagement.Services.Services
{
    public class JwtService
    {
        private JwtConfiguration _jwtConfiguration;

        public JwtService(IOptions<JwtConfiguration> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public string GenerateToken()
        {
            var claims = new List<Claim> {
                new Claim("UserName", "joey"),
                new Claim("Email", "xxx@test.com"),
                new Claim("Roles", "Admin")
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signinCredentials,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
