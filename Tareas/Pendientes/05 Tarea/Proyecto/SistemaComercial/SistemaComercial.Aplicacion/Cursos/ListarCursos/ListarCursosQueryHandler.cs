using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Cursos.Repository;

namespace SistemaComercial.Aplicacion.Cursos.ListarCursos;

internal sealed class ListarCursosQueryHandler : IQueryHandler<ListarCursosQuery, List<ListarCursosResponse>>
{
    private readonly ICursoRepository _cursoRepository;

    public ListarCursosQueryHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<List<ListarCursosResponse>> Handle(ListarCursosQuery request, CancellationToken cancellationToken)
    {
        var cursos = await _cursoRepository.ListAsync(cancellationToken);
        return cursos
            .Select(x => new ListarCursosResponse(x.Id, x.Nombre, x.CantidadHoras, x.Precio))
            .ToList();
    }
}
