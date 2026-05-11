using Empleado.Aplicacion.Cargos.CrearCargo;
using Empleado.Aplicacion.Cargos.ListarCargos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Empleado.Api.Controllers;

[ApiController]
[Route("api/cargos")]
public class CargoController : ControllerBase
{
    private readonly ISender _sender;

    public CargoController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Guid>> Create([FromBody] CrearCargoRequest request, CancellationToken cancellationToken)
    {
        var cargos = await _sender.Send(new ListarCargosQuery(), cancellationToken);
        bool isBootstrap = cargos.Count == 0;

        if (!isBootstrap && !(User.Identity?.IsAuthenticated ?? false))
            return Unauthorized("Debe autenticarse para registrar cargos.");

        var nombre = request.Nombre?.Trim();
        if (string.IsNullOrWhiteSpace(nombre))
            return BadRequest("El nombre del cargo es obligatorio.");

        var id = await _sender.Send(new CrearCargoCommand(nombre), cancellationToken);

        return Created($"/api/cargos/{id}", id);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<ListarCargosResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new ListarCargosQuery(), cancellationToken);

        bool isBootstrap = response.Count == 0;
        if (isBootstrap)
        {
            return Ok(new
            {
                mensaje = "No se encontro ningun cargo. Empieza registrando el primero.",
                cargos = response
            });
        }

        if (!(User.Identity?.IsAuthenticated ?? false))
            return Unauthorized("Debe autenticarse para listar cargos.");

        return Ok(response);
    }
}

public sealed record CrearCargoRequest(string Nombre);
