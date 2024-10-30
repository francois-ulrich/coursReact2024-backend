using Microsoft.IdentityModel.Tokens;
using sda.backend.minimalapi.Core.Auth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace sda.backend.minimalapi.Core.Auth.Interfaces
{
    public interface ITokenService
    {
        public string Create(AuthenticationUser user);
        public JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration);
    }
}
