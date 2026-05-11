using System.Security.Claims;
using Usuario.Aplication.Abstractions.Messaging;
using Usuario.Aplication.Abstractions.Security;
using Usuario.Dominio.Usuarios.Repository;

namespace Usuario.Aplication.Usuarios.JwtGenerate;

internal sealed class JwtGenerateCommandHandler : ICommandHandler<JwtGenerateCommand, JwtGenerateCommandResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public JwtGenerateCommandHandler(IUsuarioRepository usuarioRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _usuarioRepository = usuarioRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<JwtGenerateCommandResponse> Handle(JwtGenerateCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByUserNameAsync(request.NombreUsuario);

        if (usuario is null)
            return new JwtGenerateCommandResponse(string.Empty);

        if (!usuario.Password!.Value.Equals(request.Password))
            return new JwtGenerateCommandResponse(string.Empty);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.NombreUsuario!.Value),
            new Claim(ClaimTypes.Role, usuario.Rol!.NombreRol!)
        };

        var token = _jwtTokenGenerator.GenerateToken(claims);
        return new JwtGenerateCommandResponse(token);

    }
}
