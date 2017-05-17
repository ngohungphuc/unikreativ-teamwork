using Microsoft.IdentityModel.Tokens;
using System;

namespace Unikreativ.Helper.Auth
{
    public class TokenAuthOption
    {
        public static string Audience { get; } = "UnikreativAudience";
        public static string Issuer { get; } = "UnikreativIssuer";
        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromHours(6);
        public static string TokenType { get; } = "Bearer";
    }
}