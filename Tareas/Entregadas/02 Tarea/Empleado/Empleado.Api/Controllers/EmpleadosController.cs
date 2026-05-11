using Empleado.Aplicacion.Empleados.ActualizarEmpleado;
using Empleado.Aplicacion.Empleados.CrearEmpleado;
using Empleado.Aplicacion.Empleados.GetByIdEmpleado;
using Empleado.Aplicacion.Empleados.ListarEmpleados;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Empleado.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly ISender _sender;

    public EmpleadosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CrearEmpleadoCommand command, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ActualizarEmpleadoCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("El id de la ruta no coincide con el id del cuerpo.");

        await _sender.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetByIdEmpleadoResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new GetByIdEmpleadoQuery(id), cancellationToken);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<ListarEmpleadosResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new ListarEmpleadosQuery(), cancellationToken);

        return Ok(response);
    }
}
