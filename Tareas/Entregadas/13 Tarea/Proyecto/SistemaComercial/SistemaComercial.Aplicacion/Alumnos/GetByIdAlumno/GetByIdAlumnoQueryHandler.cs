using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Alumnos.Repository;

namespace SistemaComercial.Aplicacion.Alumnos.GetByIdAlumno;

internal sealed class GetByIdAlumnoQueryHandler : IQueryHandler<GetByIdAlumnoQuery, GetByIdAlumnoResponse>
{
    private readonly IAlumnoRepository _alumnoRepository;

    public GetByIdAlumnoQueryHandler(IAlumnoRepository alumnoRepository)
    {
        _alumnoRepository = alumnoRepository;
    }

    public async Task<GetByIdAlumnoResponse> Handle(GetByIdAlumnoQuery request, CancellationToken cancellationToken)
    {
        var alumno = await _alumnoRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"No existe un alumno con id '{request.Id}'.");

        return new GetByIdAlumnoResponse(alumno.Id, alumno.Nombres, alumno.Apellidos, alumno.Direccion, alumno.Ciudad);
    }
}
