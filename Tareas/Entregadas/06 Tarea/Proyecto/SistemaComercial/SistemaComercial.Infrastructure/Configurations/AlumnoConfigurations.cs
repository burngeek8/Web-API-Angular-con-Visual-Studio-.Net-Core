using SistemaComercial.Dominio.Alumnos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaComercial.Infrastructure.Configurations;

internal sealed class AlumnoConfigurations : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        builder.ToTable("alumnos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombres)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Apellidos)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Direccion)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Ciudad)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property<uint>("version").IsRowVersion();
    }
}
