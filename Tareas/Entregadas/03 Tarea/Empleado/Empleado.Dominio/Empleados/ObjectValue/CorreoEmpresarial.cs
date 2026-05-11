namespace Empleado.Dominio.Empleados.ObjectValue;

public class CorreoEmpresarial
{
    public string Valor { get; private set; }

    private CorreoEmpresarial(string valor)
    {
        Valor = valor;
    }

    public static CorreoEmpresarial Crear(string correo)
    {
        if (string.IsNullOrWhiteSpace(correo) || !EsCorreoValido(correo))
            throw new ArgumentException("El formato del correo empresarial es inválido o está vacío.");

        return new CorreoEmpresarial(correo);
    }

    private static bool EsCorreoValido(string correo)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(correo);
            return addr.Address == correo;
        }
        catch
        {
            return false;
        }
    }
}
