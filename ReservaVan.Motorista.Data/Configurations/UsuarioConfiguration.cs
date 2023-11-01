using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario", "Motorista");

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Sobrenome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Ativo)
            .IsRequired();

        builder.HasMany(p => p.Viagens)
            .WithOne(p => p.Usuario);

        builder.HasMany(p => p.Automoveis)
            .WithOne(p => p.Usuario);

        builder.Property(p => p.CriadoPor)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.CriadoEm)
            .IsRequired();

        builder.Property(p => p.EditadoPor)
            .HasMaxLength(50);
    }
}
