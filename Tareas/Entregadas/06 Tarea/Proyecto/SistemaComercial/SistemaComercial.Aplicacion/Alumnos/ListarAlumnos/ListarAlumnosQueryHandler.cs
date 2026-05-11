using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Alumnos.Repository;

namespace SistemaComercial.Aplicacion.Alumnos.ListarAlumnos;

internal sealed class ListarAlumnosQueryHandler : IQueryHandler<ListarAlumnosQuery, List<ListarAlumnosResponse>>
{
    private readonly IAlumnoRepository _alumnoRepository;

    public ListarAlumnosQueryHandler(IAlumnoRepository alumnoRepository)
    {
        _alumnoRepository = alumnoRepository;
    }

    public async Task<List<ListarAlumnosResponse>> Handle(ListarAlumnosQuery request, CancellationToken cancellationToken)
    {
        var alumnos = await _alumnoRepository.ListAsync(cancellationToken);
        return alumnos
            .Select(x => new ListarAlumnosResponse(x.Id, x.Nombres, x.Apellidos, x.Direccion, x.Ciudad))
            .ToList();
    }
}
