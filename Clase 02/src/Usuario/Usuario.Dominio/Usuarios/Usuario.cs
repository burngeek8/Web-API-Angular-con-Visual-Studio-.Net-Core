using Usuario.Dominio.Abstractions;
using Usuario.Dominio.Roles;
using Usuario.Dominio.Shared.Enum;
using Usuario.Dominio.Usuarios.ObjectValue;
using Usuario.Dominio.Usuarios.Services;

namespace Usuario.Dominio.Usuarios;

public class Usuario : Entity
{
    private Usuario(
        Guid id,
        string? nombresPersona, 
        string? apellidoPaterno, 
        string? apellidoMaterno, 
        Password? password, 
        NombreUsuario? nombreUsuario, 
        DateTime fechaNacimiento, 
        CorreoElectronico? correoElectronico, 
        Direccion? direccion, 
        Estados estado, 
        DateTime fechaUltimoCambio, 
        Guid rolId) : base(id)
    {
        NombresPersona = nombresPersona;
        ApellidoPaterno = apellidoPaterno;
        ApellidoMaterno = apellidoMaterno;
        Password = password;
        NombreUsuario = nombreUsuario;
        FechaNacimiento = fechaNacimiento;
        CorreoElectronico = correoElectronico;
        Direccion = direccion;
        Estado = estado;
        FechaUltimoCambio = fechaUltimoCambio;
        RolId = rolId;
    }

    public string? NombresPersona { get; private set; }
    public string? ApellidoPaterno { get; private set; }
    public string? ApellidoMaterno { get; private set; }
    public Password? Password { get; private set; }
    public NombreUsuario? NombreUsuario { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public CorreoElectronico? CorreoElectronico { get; private set; }
    public Direccion? Direccion { get; private set; }
    public Estados Estado { get; private set; }
    public DateTime FechaUltimoCambio { get; private set; }
    public Rol? Rol { get; private set; }
    public Guid RolId { get; private set; }

    public static Usuario Create(
        string nombresPersona, 
        string apellidoPaterno, 
        string? apellidoMaterno, 
        Password? password, 
        DateTime fechaNacimiento, 
        CorreoElectronico? correoElectronico, 
        Direccion? direccion, 
        DateTime fechaUltimoCambio, 
        Guid rolId,
        NombreUsuarioServices nombreUsuarioServices)
    {
        var nombreUsuarioGenerado = nombreUsuarioServices.GenerarNombreUsuario(nombresPersona, apellidoPaterno);

        var usuario = new Usuario(
            Guid.NewGuid(), 
            nombresPersona, 
            apellidoPaterno, 
            apellidoMaterno, 
            password, 
            nombreUsuarioGenerado, 
            fechaNacimiento, 
            correoElectronico, 
            direccion, 
            Estados.Activo, 
            fechaUltimoCambio, 
            rolId);

        return usuario;
    }
}