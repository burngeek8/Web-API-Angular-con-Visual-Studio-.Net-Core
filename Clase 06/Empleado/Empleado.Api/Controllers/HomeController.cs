using Empleado.Dominio.Cargos;
using Empleado.Dominio.Empleados.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Empleado.Api.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    private const string RegistroCargoUrl = "/api/cargos";
    private const string RegistroEmpleadoUrl = "/api/empleados";
    private readonly ICargoRepository _cargoRepository;
    private readonly IEmpleadoRepository _empleadoRepository;

    public HomeController(ICargoRepository cargoRepository, IEmpleadoRepository empleadoRepository)
    {
        _cargoRepository = cargoRepository;
        _empleadoRepository = empleadoRepository;
    }

    [HttpGet("/")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        // ExistsAnyAsync usa AnyAsync en la BD: true si existe al menos un registro, false si la tabla esta vacia.
        bool existeCargo = await _cargoRepository.ExistsAnyAsync(cancellationToken);
        bool existeEmpleado = await _empleadoRepository.ExistsAnyAsync(cancellationToken);

        if (!existeCargo && !existeEmpleado)
        {
            return Ok(new
            {
                inicializada = false,
                mensaje = "La API aun no se encuentra inicializada.",
                primerCargo = new
                {
                    mensaje = "Debe crear el primer cargo desde esta ruta.",
                    url = RegistroCargoUrl
                },
                primerEmpleado = new
                {
                    mensaje = "El primer empleado aun no se encuentra creado y debe registrarlo desde esta ruta. Asegurese de crear primero el cargo.",
                    url = RegistroEmpleadoUrl
                }
            });
        }

        if (!existeCargo)
        {
            return Ok(new
            {
                inicializada = false,
                mensaje = "No existen cargos registrados.",
                primerCargo = new
                {
                    mensaje = "Debe crear el primer cargo desde esta ruta.",
                    url = RegistroCargoUrl
                }
            });
        }

        if (!existeEmpleado)
        {
            return Ok(new
            {
                inicializada = false,
                mensaje = "El primer empleado aun no se encuentra creado.",
                primerEmpleado = new
                {
                    mensaje = "Debe registrar el primer empleado desde esta ruta.",
                    url = RegistroEmpleadoUrl
                }
            });
        }

        return Ok(new
        {
            inicializada = true,
            mensaje = "API inicializada correctamente."
        });
    }
}
