using SistemaComercial.Dominio.Ventas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaComercial.Infrastructure.Configurations;

internal sealed class DetalleVentaConfigurations : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("detalle_ventas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Cantidad)
            .IsRequired();

        builder.Property(x => x.Precio)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Total)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne(x => x.Curso)
            .WithMany()
            .HasForeignKey(x => x.CursoId)
            .IsRequired();

        builder.Property<uint>("version").IsRowVersion();
    }
}
