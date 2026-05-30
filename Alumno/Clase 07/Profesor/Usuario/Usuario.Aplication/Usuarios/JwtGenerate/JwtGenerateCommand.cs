
using Usuario.Aplication.Abstractions.Messaging;

namespace Usuario.Aplication.Usuarios.JwtGenerate;

public sealed record JwtGenerateCommand
(
    string NombreUsuario,
    string Password
) : ICommand<JwtGenerateCommandResponse>;