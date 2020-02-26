namespace EBook.Services
{
    using EBook.Services.Contracts;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class TokenService : ITokenService
    {
        private const string JwtSectionKey = "jwt";
        private const string JwtSecretKey = "secretKey";
        private const string JwtIssuerKey = "issuer";
        private const string JwtAudienceKey = "audience";

        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
            => _config = config;

        public string GenerateToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetJwtSecretKey()));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: GetJwtIssuer(),
                claims: new List<Claim>(),
                audience: GetJwtAudience(),
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        private string GetJwtSecretKey() => _config.GetSection(JwtSectionKey).GetValue<string>(JwtSecretKey);
        private string GetJwtIssuer() => _config.GetSection(JwtSectionKey).GetValue<string>(JwtIssuerKey);
        private string GetJwtAudience() => _config.GetSection(JwtSectionKey).GetValue<string>(JwtAudienceKey);
    }
}
