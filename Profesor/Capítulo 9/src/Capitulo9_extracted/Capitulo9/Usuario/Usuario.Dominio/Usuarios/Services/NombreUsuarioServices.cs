using Usuario.Dominio.Usuarios.ObjectValue;

namespace Usuario.Dominio.Usuarios.Services;

public class NombreUsuarioServices
{
    public NombreUsuario GenerarNombreUsuario(string nombre, string apellido)
    {
        // Genera un nombre de usuario simple combinando el nombre y apellido
        string nombreUsuario = $"{nombre.Substring(0, 1).ToUpper()}.{apellido.ToUpper()}";
        return NombreUsuario.Create(nombreUsuario);
    }
}
