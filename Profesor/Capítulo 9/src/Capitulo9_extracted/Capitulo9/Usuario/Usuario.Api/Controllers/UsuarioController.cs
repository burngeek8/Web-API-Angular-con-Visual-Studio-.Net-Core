using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Usuario.Aplication.Usuarios.CrearUsuario;
using Usuario.Aplication.Usuarios.GetByIdUsuario;
using Usuario.Aplication.Usuarios.JwtGenerate;

namespace Usuario.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsuarioController : ControllerBase
{
    private readonly ISender _mediador;

    public UsuarioController(ISender mediador)
    {
        _mediador = mediador;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuario(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetByIdUsuarioQuery(id);
        var result = await _mediador.Send(query, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUsuario
        (CreateUsuarioRequest request, 
        CancellationToken cancellationToken)
    {
        var command = new CrearUsuarioCommand(
            request.NombresPersona,
            request.ApellidoPaterno,
            request.ApellidoMaterno,
            request.Password,
            request.FechaNacimiento,
            request.CorreoElectronico,
            request.Pais,
            request.Departamento,
            request.Provincia,
            request.Distrito,
            request.Calle,
            request.NombreRol
        );
        var result = await _mediador.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var command = new JwtGenerateCommand(request.NombreUsuario, request.Password);
        var result = await _mediador.Send(command, cancellationToken);
        return string.IsNullOrEmpty(result.Token) ? Unauthorized() : Ok(result);
    }
}
