using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Abstractions;
using SistemaComercial.Dominio.Alumnos;
using SistemaComercial.Dominio.Alumnos.Repository;

namespace SistemaComercial.Aplicacion.Alumnos.CrearAlumno;

internal sealed class CrearAlumnoCommandHandler : ICommandHandler<CrearAlumnoCommand, CrearAlumnoResponse>
{
    private readonly IAlumnoRepository _alumnoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrearAlumnoCommandHandler(IAlumnoRepository alumnoRepository, IUnitOfWork unitOfWork)
    {
        _alumnoRepository = alumnoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CrearAlumnoResponse> Handle(CrearAlumnoCommand request, CancellationToken cancellationToken)
    {
        var alumno = Alumno.Create(request.Nombres, request.Apellidos, request.Direccion, request.Ciudad);
        _alumnoRepository.Add(alumno);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new CrearAlumnoResponse(alumno.Id);
    }
}
