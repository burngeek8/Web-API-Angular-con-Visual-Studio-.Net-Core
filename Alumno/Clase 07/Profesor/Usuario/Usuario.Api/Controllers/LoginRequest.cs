namespace Usuario.Api.Controllers;

public sealed record LoginRequest
(
    string NombreUsuario,
    string Password
);
