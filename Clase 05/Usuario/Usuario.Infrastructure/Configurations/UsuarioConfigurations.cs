using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Dominio.Shared.Enum;
using Usuario.Dominio.Usuarios.ObjectValue;

namespace Usuario.Infrastructure.Configurations;

internal class UsuarioConfigurations : IEntityTypeConfiguration<Dominio.Usuarios.Usuario>
{
    public void Configure(EntityTypeBuilder<Dominio.Usuarios.Usuario> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.NombresPersona)
            .HasMaxLength(100).
            IsRequired();

        builder.Property(u => u.ApellidoPaterno)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.ApellidoMaterno)
            .HasMaxLength(50);

        builder.Property(p => p.Password)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(), // Convertir a string para almacenar en la base de datos
                v => Password.Create(v) // Convertir de string a Password al leer de la base de datos
            ).IsRequired();

        builder.Property( n => n.NombreUsuario)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(), // Convertir a string para almacenar en la base de datos
                v => NombreUsuario.Create(v) // Convertir de string a NombreUsuario al leer de la base de datos
            ).IsRequired();

        builder.Property(u => u.FechaNacimiento)
            .IsRequired();

        builder.Property(u => u.CorreoElectronico)
            .HasMaxLength(100)
            .HasConversion(
                v => v.ToString(), // Convertir a string para almacenar en la base de datos
                v => CorreoElectronico.Crear(v) // Convertir de string a CorreoElectronico al leer de la base de datos
            ).IsRequired();

        builder.HasIndex(c => c.CorreoElectronico).IsUnique();

        builder.HasIndex(n => n.NombreUsuario).IsUnique();

        builder.OwnsOne(u => u.Direccion);

        builder.Property(u => u.Estado)
            .HasConversion(
                v => v.ToString(), // Convertir a string para almacenar en la base de datos
                v => (Estados)Enum.Parse(typeof(Estados), v) // Convertir de string a Estados al leer de la base de datos
            )
            .IsRequired();

        builder.Property(u => u.FechaUltimoCambio).IsRequired();

        builder.HasOne(u => u.Rol)
            .WithMany()
            .HasForeignKey(u => u.RolId)
            .IsRequired();

        builder.Property<uint>("version").IsRowVersion();

    }
}
