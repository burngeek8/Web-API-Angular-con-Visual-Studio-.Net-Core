using System.Security.Claims;

namespace Usuario.Aplication.Abstractions.Security;

public interface IJwtTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claim);
}
