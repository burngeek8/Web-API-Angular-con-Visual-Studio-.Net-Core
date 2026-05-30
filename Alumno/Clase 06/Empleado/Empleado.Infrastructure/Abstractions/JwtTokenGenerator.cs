using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Empleado.Aplicacion.Abstractions.Security;
using Microsoft.IdentityModel.Tokens;

namespace Empleado.Infrastructure.Abstractions;

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _jwtOptions;

    public JwtTokenGenerator(JwtOptions jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }

    public string GenerateToken(IEnumerable<Claim> claim)
    {
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claim,
            expires: DateTime.Now.AddMinutes(_jwtOptions.ExpirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
