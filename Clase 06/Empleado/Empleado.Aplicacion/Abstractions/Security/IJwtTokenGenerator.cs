using System.Security.Claims;

namespace Empleado.Aplicacion.Abstractions.Security;

public interface IJwtTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claim);
}
