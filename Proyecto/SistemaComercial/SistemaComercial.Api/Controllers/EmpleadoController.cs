using SistemaComercial.Aplicacion.Empleados.ActualizarEmpleado;
using SistemaComercial.Aplicacion.Empleados.CrearEmpleado;
using SistemaComercial.Aplicacion.Empleados.GetByIdEmpleado;
using SistemaComercial.Aplicacion.Empleados.ListarEmpleados;
using SistemaComercial.Aplicacion.Empleados.LoginEmpleado;
using SistemaComercial.Dominio.Cargos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaComercial.Api.Controllers;

[ApiController]
[Route("api/empleados")]
public class EmpleadoController : ControllerBase
{
    private const string PrimerCargoRegistroUrl = "/api/cargos";
    private readonly ISender _sender;
    private readonly ICargoRepository _cargoRepository;

    public EmpleadoController(ISender sender, ICargoRepository cargoRepository)
    {
        _sender = sender;
        _cargoRepository = cargoRepository;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<CrearEmpleadoResponse>> Create([FromBody] CrearEmpleadoCommand command, CancellationToken cancellationToken)
    {
        var empleados = await _sender.Send(new ListarEmpleadosQuery(), cancellationToken);
        bool isBootstrap = empleados.Count == 0;

        if (!isBootstrap && !(User.Identity?.IsAuthenticated ?? false))
            return Unauthorized("Debe autenticarse para crear empleados.");

        bool existeAlgunCargo = await _cargoRepository.ExistsAnyAsync(cancellationToken);
        if (!existeAlgunCargo)
        {
            return BadRequest(new
            {
                mensaje = "No existen cargos registrados. Debe registrar el primer cargo antes de crear empleados.",
                url = PrimerCargoRegistroUrl
            });
        }

        var result = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromBody] ActualizarEmpleadoCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("El id de la ruta no coincide con el id del cuerpo.");

        await _sender.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<GetByIdEmpleadoResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new GetByIdEmpleadoQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<ListarEmpleadosResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new ListarEmpleadosQuery(), cancellationToken);

        bool isBootstrap = response.Count == 0;
        if (isBootstrap)
        {
            return Ok(new
            {
                mensaje = "No se encontro ningun empleado. Empieza registrando el primero.",
                empleados = response
            });
        }

        if (!(User.Identity?.IsAuthenticated ?? false))
            return Unauthorized("Debe autenticarse para listar empleados.");

        return Ok(response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginEmpleadoRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginEmpleadoCommand(request.CorreoEmpresarial, request.Clave);
        var result = await _sender.Send(command, cancellationToken);
        return string.IsNullOrEmpty(result.Token) ? Unauthorized() : Ok(result);
    }
}
