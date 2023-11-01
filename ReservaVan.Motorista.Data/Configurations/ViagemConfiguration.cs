using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class ViagemConfiguration : IEntityTypeConfiguration<Viagem>
{
    public void Configure(EntityTypeBuilder<Viagem> builder)
    {
        builder.ToTable("Viagem", "Motorista");

        builder.Property(p => p.Valor)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(p => p.DataHoraPartida)
            .IsRequired();

        builder.HasMany(p => p.Reservas)
            .WithOne(p => p.Viagem);

        builder.HasOne(p => p.Usuario)
            .WithMany(p => p.Viagens);

        builder.HasOne(p => p.Automovel)
            .WithMany(p => p.Viagens);

        builder.Property(p => p.CriadoPor)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.CriadoEm)
            .IsRequired();

        builder.Property(p => p.EditadoPor)
            .HasMaxLength(50);
    }
}
