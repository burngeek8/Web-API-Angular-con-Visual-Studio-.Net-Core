namespace Usuario.Dominio.Usuarios.ObjectValue;

public record class Direccion
(
    string Pais,
    string Departamento,
    string Provincia,
    string Distrito,
    string Calle
);