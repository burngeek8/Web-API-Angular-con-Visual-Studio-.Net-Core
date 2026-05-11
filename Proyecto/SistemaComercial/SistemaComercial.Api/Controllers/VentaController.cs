using SistemaComercial.Aplicacion.Ventas.GetVentaBySerieNumero;
using SistemaComercial.Aplicacion.Ventas.ListarVentas;
using SistemaComercial.Aplicacion.Ventas.RegistrarVenta;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaComercial.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/ventas")]
public class VentaController : ControllerBase
{
    private readonly ISender _sender;

    public VentaController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<RegistrarVentaResponse>> Create([FromBody] RegistrarVentaCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetByCodigo), new { serie = result.Serie, numero = result.Numero }, result);
    }

    [HttpGet("{serie}/{numero:int}")]
    public async Task<ActionResult<GetVentaBySerieNumeroResponse>> GetByCodigo(string serie, int numero, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new GetVentaBySerieNumeroQuery(serie, numero), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<ListarVentasResponse>>> GetAll(
        [FromQuery] DateTime? fechaInicio,
        [FromQuery] DateTime? fechaFin,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new ListarVentasQuery(fechaInicio, fechaFin), cancellationToken);
        return Ok(response);
    }
}
