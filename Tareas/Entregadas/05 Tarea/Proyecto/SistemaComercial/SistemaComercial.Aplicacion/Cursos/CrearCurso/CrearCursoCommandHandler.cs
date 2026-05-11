using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Abstractions;
using SistemaComercial.Dominio.Cursos;
using SistemaComercial.Dominio.Cursos.Repository;

namespace SistemaComercial.Aplicacion.Cursos.CrearCurso;

internal sealed class CrearCursoCommandHandler : ICommandHandler<CrearCursoCommand, CrearCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrearCursoCommandHandler(ICursoRepository cursoRepository, IUnitOfWork unitOfWork)
    {
        _cursoRepository = cursoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CrearCursoResponse> Handle(CrearCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = Curso.Create(request.Nombre, request.CantidadHoras, request.Precio);
        _cursoRepository.Add(curso);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new CrearCursoResponse(curso.Id);
    }
}
