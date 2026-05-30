using Empleado.Dominio.Empleados.ObjectValue;
using Empleado.Dominio.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empleado.Infrastructure.Configurations;

internal class EmpleadoConfigurations : IEntityTypeConfiguration<Empleado.Dominio.Empleados.Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado.Dominio.Empleados.Empleado> builder)
    {
        builder.ToTable("empleados");
        builder.HasKey(e => e.Id);

        builder.OwnsOne(e => e.NombreCompleto, nc =>
        {
            nc.Property(n => n.Nombres).HasMaxLength(100).IsRequired();
            nc.Property(n => n.ApellidoPaterno).HasMaxLength(50).IsRequired();
            nc.Property(n => n.ApellidoMaterno).HasMaxLength(50);
        });

        builder.OwnsOne(e => e.NumeroDocumento, nd =>
        {
            nd.Property(n => n.Valor).HasMaxLength(12).IsRequired();
            nd.Property(n => n.Tipo)
                .HasConversion(
                    v => v.ToString(),
                    v => (TipoDocumento)Enum.Parse(typeof(TipoDocumento), v)
                )
                .IsRequired();
        });

        builder.Property(e => e.CorreoEmpresarial)
            .HasMaxLength(100)
            .HasConversion(
                v => v.Valor,
                v => CorreoEmpresarial.Crear(v)
            )
            .IsRequired();

        builder.HasIndex(e => e.CorreoEmpresarial).IsUnique();

        builder.OwnsOne(e => e.Salario, s =>
        {
            s.Property(n => n.Monto).HasColumnType("decimal(18,2)").IsRequired();
            s.Property(n => n.Moneda).HasMaxLength(3).IsRequired();
        });

        builder.Property(e => e.CodigoEmpleado)
            .HasMaxLength(60)
            .HasConversion(
                v => v.Valor,
                v => CodigoEmpleado.Create(v)
            )
            .IsRequired();

        builder.HasIndex(e => e.CodigoEmpleado).IsUnique();

        builder.Property(e => e.Clave)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(e => e.FechaIngreso).IsRequired();

        builder.Property(e => e.Estado)
            .HasConversion(
                v => v.ToString(),
                v => (EstadoEmpleado)Enum.Parse(typeof(EstadoEmpleado), v)
            )
            .IsRequired();

        builder.HasOne(e => e.Cargo)
            .WithMany()
            .HasForeignKey(e => e.CargoId)
            .IsRequired();

        builder.Property<uint>("version").IsRowVersion();
    }
}
