using SistemaComercial.Aplicacion.Cursos.CrearCurso;
using SistemaComercial.Aplicacion.Cursos.GetByIdCurso;
using SistemaComercial.Aplicacion.Cursos.ListarCursos;
using SistemaComercial.Api.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaComercial.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.GerenteGeneral},{Roles.Vendedor}")]
[Route("api/cursos")]
public class CursoController : ControllerBase
{
    private readonly ISender _sender;

    public CursoController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<CrearCursoResponse>> Create([FromBody] CrearCursoCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetByIdCursoResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new GetByIdCursoQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<ListarCursosResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new ListarCursosQuery(), cancellationToken);
        return Ok(response);
    }
}
