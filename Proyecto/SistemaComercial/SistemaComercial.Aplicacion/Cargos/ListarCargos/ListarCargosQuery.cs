using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Cargos.ListarCargos;

public sealed record ListarCargosQuery(string? Q = null) : IQuery<List<ListarCargosResponse>>;
