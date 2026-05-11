using Empleado.Aplicacion.Abstractions.Messaging;

namespace Empleado.Aplicacion.Cargos.CrearCargo;

public sealed record CrearCargoCommand(string Nombre) : ICommand<Guid>;
