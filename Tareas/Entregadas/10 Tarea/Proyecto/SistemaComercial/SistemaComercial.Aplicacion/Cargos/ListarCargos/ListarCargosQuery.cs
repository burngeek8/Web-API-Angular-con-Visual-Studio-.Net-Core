using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Cargos.ListarCargos;

public sealed record ListarCargosQuery : IQuery<List<ListarCargosResponse>>;
