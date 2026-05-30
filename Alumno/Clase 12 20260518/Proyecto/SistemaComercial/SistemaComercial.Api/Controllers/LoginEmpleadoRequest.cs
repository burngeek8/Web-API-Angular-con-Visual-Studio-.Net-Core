namespace SistemaComercial.Api.Controllers;

public sealed record LoginEmpleadoRequest(
    string CorreoEmpresarial,
    string Clave
);
