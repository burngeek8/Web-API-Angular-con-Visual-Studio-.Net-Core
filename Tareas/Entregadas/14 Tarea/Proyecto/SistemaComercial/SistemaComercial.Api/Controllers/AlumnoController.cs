using SistemaComercial.Aplicacion.Alumnos.CrearAlumno;
using SistemaComercial.Aplicacion.Alumnos.GetByIdAlumno;
using SistemaComercial.Aplicacion.Alumnos.ListarAlumnos;
using SistemaComercial.Api.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaComercial.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.GerenteGeneral},{Roles.Vendedor}")]
[Route("api/alumnos")]
public class AlumnoController : ControllerBase
{
    private readonly ISender _sender;

    public AlumnoController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<CrearAlumnoResponse>> Create([FromBody] CrearAlumnoCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetByIdAlumnoResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new GetByIdAlumnoQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<ListarAlumnosResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new ListarAlumnosQuery(), cancellationToken);
        return Ok(response);
    }
}
