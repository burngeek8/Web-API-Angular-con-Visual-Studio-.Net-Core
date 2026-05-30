using SistemaComercial.Aplicacion.Empleados.LoginEmpleado;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaComercial.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginEmpleadoRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginEmpleadoCommand(request.CorreoEmpresarial, request.Clave);
        var result = await _sender.Send(command, cancellationToken);
        return string.IsNullOrEmpty(result.AccessToken) ? Unauthorized() : Ok(result);
    }
}
