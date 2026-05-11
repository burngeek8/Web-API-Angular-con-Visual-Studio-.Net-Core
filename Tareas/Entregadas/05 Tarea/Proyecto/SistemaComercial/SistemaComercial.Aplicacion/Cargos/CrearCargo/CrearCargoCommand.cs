using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Cargos.CrearCargo;

public sealed record CrearCargoCommand(string Nombre) : ICommand<Guid>;
