using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using StorageMapper.Application.Interfaces;
using StorageMapper.Domain.Entitites;
using System.Security.Cryptography;

namespace StorageMapper.Infrastructure.Providers;

public sealed class TokenProvider : ITokenProvider
{
    private readonly IConfiguration _config;
    public TokenProvider(IConfiguration config) => _config = config;

    public string Create(User user)
    {
        string secretKey = _config["Jwt:SecretKey"]!;
        byte[] secretKeyAsBytes = Encoding.UTF8.GetBytes(secretKey);
        var securityKey = new SymmetricSecurityKey(secretKeyAsBytes);

        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
        Claim[] claims = [
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email.ToString()),
        ];
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_config.GetValue<int>("Jwt:ExpirationInMinutes")),
            SigningCredentials = credentials,
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"]
        };

        JsonWebTokenHandler handler = new();
        string token = handler.CreateToken(descriptor);
        return token;
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}
