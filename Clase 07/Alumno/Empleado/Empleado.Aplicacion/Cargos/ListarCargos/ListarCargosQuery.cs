using Empleado.Aplicacion.Abstractions.Messaging;

namespace Empleado.Aplicacion.Cargos.ListarCargos;

public sealed record ListarCargosQuery : IQuery<List<ListarCargosResponse>>;
