using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Cursos.Repository;

namespace SistemaComercial.Aplicacion.Cursos.GetByIdCurso;

internal sealed class GetByIdCursoQueryHandler : IQueryHandler<GetByIdCursoQuery, GetByIdCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;

    public GetByIdCursoQueryHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<GetByIdCursoResponse> Handle(GetByIdCursoQuery request, CancellationToken cancellationToken)
    {
        var curso = await _cursoRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"No existe un curso con id '{request.Id}'.");

        return new GetByIdCursoResponse(curso.Id, curso.Nombre, curso.CantidadHoras, curso.Precio);
    }
}
