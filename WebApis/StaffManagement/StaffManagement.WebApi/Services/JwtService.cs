using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StaffManagement.WebApi.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StaffManagement.WebApi.Services
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
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
