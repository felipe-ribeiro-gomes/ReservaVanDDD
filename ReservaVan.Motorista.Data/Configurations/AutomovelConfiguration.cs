using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class AutomovelConfiguration : IEntityTypeConfiguration<Automovel>
{
    public void Configure(EntityTypeBuilder<Automovel> builder)
    {
        builder.ToTable("Automovel", "Motorista");

        builder.Property(p => p.Marca)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Modelo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Cor)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Placa)
            .IsRequired()
            .HasMaxLength(7);

        builder.Property(p => p.QtdVaga)
            .IsRequired();

        builder.HasMany(p => p.Viagens)
            .WithOne(p => p.Automovel);

        builder.HasOne(p => p.Usuario)
            .WithMany(p => p.Automoveis)
            .HasForeignKey("UsuarioId")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(p => p.CriadoPor)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.CriadoEm)
            .IsRequired();

        builder.Property(p => p.EditadoPor)
            .HasMaxLength(50);
    }
}
