using Usuario.Aplication.Abstractions.Messaging;
using Usuario.Dominio.Abstractions;
using Usuario.Dominio.Roles;
using Usuario.Dominio.Usuarios.ObjectValue;
using Usuario.Dominio.Usuarios.Repository;
using Usuario.Dominio.Usuarios.Services;

namespace Usuario.Aplication.Usuarios.CrearUsuario;

internal sealed class CrearUsuarioCommandHandler : ICommandHandler<CrearUsuarioCommand, Guid>
{
    private readonly IRolRepository _rolRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly NombreUsuarioServices _nombreUsuarioServices;
    private readonly IUnitOfWork _unitOfWork;

    public CrearUsuarioCommandHandler(
        IRolRepository rolRepository,
        IUsuarioRepository usuarioRepository,
        NombreUsuarioServices nombreUsuarioServices,
        IUnitOfWork unitOfWork)
    {
        _rolRepository = rolRepository;
        _usuarioRepository = usuarioRepository;
        _nombreUsuarioServices = nombreUsuarioServices;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
    {
        var rol = await _rolRepository.GetByNombreAsync(request.NombreRol, cancellationToken);
        if (rol is null)
            throw new Exception($"El rol '{request.NombreRol}' no existe.");

        var password = Password.Create(request.Password);
        if (password == null)
            throw new Exception("La contraseña no es válida.");

        var correo = CorreoElectronico.Crear(request.CorreoElectronico);
        if (correo == null)
            throw new Exception("El correo electrónico no es válido.");

        var usuario = Dominio.Usuarios.Usuario.Create(
                request.NombresPersona,
                request.ApellidoPaterno,
                request.ApellidoMaterno,
                password,
                request.FechaNacimiento.ToUniversalTime(),
                correo,
                new Direccion(request.Pais, request.Departamento, request.Provincia, request.Distrito, request.Calle),
                DateTime.UtcNow,
                rol.Id,
                _nombreUsuarioServices
            );

        _usuarioRepository.Add(usuario);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return usuario.Id;
    }
}
