using SistemaComercial.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaComercial.Infrastructure.Configurations;

internal sealed class CursoConfigurations : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("cursos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.CantidadHoras)
            .IsRequired();

        builder.Property(x => x.Precio)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property<uint>("version").IsRowVersion();
    }
}
