using SistemaComercial.Dominio.Shared.Enum;

namespace SistemaComercial.Dominio.Empleados.ObjectValue;

public record NumeroDocumento
{
    public string Valor { get; init; }
    public TipoDocumento Tipo { get; init; }

    private NumeroDocumento()
    {
        Valor = string.Empty;
    }

    private NumeroDocumento(string valor, TipoDocumento tipo)
    {
        Valor = valor;
        Tipo = tipo;
    }

    public static NumeroDocumento Create(string valor, TipoDocumento tipo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("El número de documento no puede estar vacío.");

        switch (tipo)
        {
            case TipoDocumento.DNI:
                if (valor.Length != 8 || !valor.All(char.IsDigit))
                    throw new ArgumentException("El DNI debe tener exactamente 8 dígitos numéricos.");
                break;

            case TipoDocumento.CarnetExtranjeria:
                if (valor.Length != 9 || !valor.All(char.IsDigit))
                    throw new ArgumentException("El Carnet de Extranjería debe tener exactamente 9 dígitos numéricos.");
                break;

            case TipoDocumento.Pasaporte:
                if (valor.Length < 6 || valor.Length > 12)
                    throw new ArgumentException("El Pasaporte debe tener entre 6 y 12 caracteres.");
                break;
        }

        return new NumeroDocumento(valor, tipo);
    }
}
