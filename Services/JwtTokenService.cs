using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using sda.backend.minimalapi.Core.Auth.Interfaces;
using sda.backend.minimalapi.Core.Auth.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace sda.backend.minimalapi.Core.Auth.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly double _expirationTimeInMinutes = 30;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Create(AuthenticationUser user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(_expirationTimeInMinutes);

            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration)
        {
            return new(
                _configuration.GetSection("Jwt")["ValidIssuer"],
                _configuration.GetSection("Jwt")["ValidAudience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }

        public List<Claim> CreateClaims(AuthenticationUser user)
        {
            //var jwtSub = _configuration.GetSection("Jwt")["RegisteredClaimNamesSub"];

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, user.Id),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                
                //new Claim(ClaimTypes.NameIdentifier, user.Id),
                //new Claim(ClaimTypes.Name, username),
                //new Claim(ClaimTypes.Role, role)

                new (ClaimTypes.Email, user.Email!)
            };

            return claims;
        }

        private SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = _configuration.GetSection("Jwt")["SymmetricSecurityKey"];

            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(symmetricSecurityKey!)
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
