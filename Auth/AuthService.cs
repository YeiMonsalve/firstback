using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackendProject.Models;
using Microsoft.IdentityModel.Tokens;


namespace BackendProject.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config) => _config = config;
        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role)
 };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
