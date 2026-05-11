using SistemaComercial.Dominio.Ventas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaComercial.Infrastructure.Configurations;

internal sealed class VentaConfigurations : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("ventas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Serie)
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(x => x.Numero)
            .IsRequired();

        builder.Property(x => x.Fecha)
            .IsRequired();

        builder.Property(x => x.Total)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasIndex(x => new { x.Serie, x.Numero })
            .IsUnique();

        builder.HasOne(x => x.Alumno)
            .WithMany()
            .HasForeignKey(x => x.AlumnoId)
            .IsRequired();

        builder.HasMany(x => x.Detalles)
            .WithOne()
            .HasForeignKey(x => x.VentaId)
            .IsRequired();

        builder.Navigation(x => x.Detalles)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Property<uint>("version").IsRowVersion();
    }
}
