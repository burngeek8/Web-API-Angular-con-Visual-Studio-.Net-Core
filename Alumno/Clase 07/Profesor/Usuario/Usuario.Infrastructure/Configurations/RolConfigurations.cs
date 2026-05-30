using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Dominio.Roles;

namespace Usuario.Infrastructure.Configurations;

internal class RolConfigurations : IEntityTypeConfiguration<Dominio.Roles.Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("roles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NombreRol)
            .HasColumnName("nombre_rol")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property<uint>("version").IsRowVersion();
    }
}
