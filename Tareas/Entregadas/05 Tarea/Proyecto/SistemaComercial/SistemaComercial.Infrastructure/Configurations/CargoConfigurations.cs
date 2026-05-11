using SistemaComercial.Dominio.Cargos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaComercial.Infrastructure.Configurations;

internal class CargoConfigurations : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.ToTable("cargos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.Nombre)
            .IsUnique();

        builder.Property<uint>("version").IsRowVersion();
    }
}
