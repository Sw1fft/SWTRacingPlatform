using IdentityService.Domain.Abstractions.Services;
using IdentityService.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        #region private
        private readonly JwtOptions _jwtOptions;
        #endregion

        public JwtService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public Task<string> GenerateToken(User user)
        {
            Claim[] claims = 
                [
                    new("username", user.Username),
                    new("email", user.Email)
                ];

            SigningCredentials credentials = new(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(12));

            string value = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(value);
        }
    }
}
