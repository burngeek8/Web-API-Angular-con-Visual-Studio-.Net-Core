using Usuario.Aplication.Abstractions.Messaging;

namespace Usuario.Aplication.Usuarios.GetByIdUsuario;

public sealed record GetByIdUsuarioQuery(Guid Id) : IQuery<GetByIdUsuarioResponse>
{
}
