using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Domus.API.DTOs.Token;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Domus.API.Services.Implementations;

// Generates a JWT
public class TokenService {
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration) {
        _configuration = configuration;
    }

    public string GenerateToken(TokenDataDto dto) {
        var handler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(_configuration["JWT_SECRET"]!);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = GenerateClaimsIdentity(dto),
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddDays(7)
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    public static ClaimsIdentity GenerateClaimsIdentity(TokenDataDto dto) {
        var ci = new ClaimsIdentity();
        ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, dto.Id));
        ci.AddClaim(new Claim(ClaimTypes.Name, dto.Username));
        return ci;
    }
}