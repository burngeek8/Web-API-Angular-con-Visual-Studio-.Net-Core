using System.Security.Claims;
using Empleado.Aplicacion.Abstractions.Messaging;
using Empleado.Aplicacion.Abstractions.Security;
using Empleado.Dominio.Cargos;
using Empleado.Dominio.Empleados.Repository;

namespace Empleado.Aplicacion.Empleados.LoginEmpleado;

internal sealed class LoginEmpleadoCommandHandler : ICommandHandler<LoginEmpleadoCommand, LoginEmpleadoResponse>
{
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly ICargoRepository _cargoRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginEmpleadoCommandHandler(
        IEmpleadoRepository empleadoRepository,
        ICargoRepository cargoRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _empleadoRepository = empleadoRepository;
        _cargoRepository = cargoRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginEmpleadoResponse> Handle(LoginEmpleadoCommand request, CancellationToken cancellationToken)
    {
        var empleado = await _empleadoRepository.GetByCorreoEmpresarialAsync(request.CorreoEmpresarial, cancellationToken);
        if (empleado is null)
            return new LoginEmpleadoResponse(string.Empty);

        if (!empleado.Clave.Equals(request.Clave))
            return new LoginEmpleadoResponse(string.Empty);

        var cargo = await _cargoRepository.GetByIdAsync(empleado.CargoId, cancellationToken);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, empleado.Id.ToString()),
            new Claim(ClaimTypes.Name, empleado.CorreoEmpresarial.Valor),
            new Claim(ClaimTypes.Role, cargo?.Nombre ?? "Empleado")
        };

        var token = _jwtTokenGenerator.GenerateToken(claims);
        return new LoginEmpleadoResponse(token);
    }
}
