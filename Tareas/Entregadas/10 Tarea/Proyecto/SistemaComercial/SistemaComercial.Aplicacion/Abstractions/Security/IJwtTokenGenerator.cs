using System.Security.Claims;

namespace SistemaComercial.Aplicacion.Abstractions.Security;

public interface IJwtTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claim);
}
