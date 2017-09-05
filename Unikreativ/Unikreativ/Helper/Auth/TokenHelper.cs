using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Helper.Auth
{
    public static class TokenHelper
    {
        public static string GenerateToken(User user, DateTime expiresIn)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "TokenAuth"),
                new[]
                {
                     new Claim("ID", user.Id)
                }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expiresIn
            });

            return handler.WriteToken(securityToken);
        }
    }
}