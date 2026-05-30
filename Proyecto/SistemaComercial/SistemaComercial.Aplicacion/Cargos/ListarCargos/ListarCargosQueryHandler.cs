using Dapper;
using SistemaComercial.Aplicacion.Abstractions.Data;
using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Cargos.ListarCargos;

internal sealed class ListarCargosQueryHandler : IQueryHandler<ListarCargosQuery, List<ListarCargosResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ListarCargosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<ListarCargosResponse>> Handle(ListarCargosQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """
            SELECT
                c.id,
                c.nombre
            FROM cargos c
            WHERE (@Q IS NULL OR c.nombre ILIKE '%' || @Q || '%')
            ORDER BY c.nombre
            """;

        var result = await connection.QueryAsync<ListarCargosResponse>(sql, new
        {
            Q = string.IsNullOrWhiteSpace(request.Q) ? null : request.Q.Trim()
        });
        return result.ToList();
    }
}
