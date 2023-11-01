using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.ToTable("Reserva", "Motorista");

        builder.Property(p => p.Posicao)
            .IsRequired();

        builder.Property(p => p.FormaPagamento)
            .IsRequired();

        builder.Property(p => p.EstaPago)
            .IsRequired();

        builder.Property(p => p.Observacao)
            .HasMaxLength(500);

        builder.HasOne(p => p.Passageiro)
            .WithMany(p => p.Reservas);

        builder.HasOne(p => p.Viagem)
            .WithMany(p => p.Reservas);

        builder.Property(p => p.CriadoPor)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.CriadoEm)
            .IsRequired();

        builder.Property(p => p.EditadoPor)
            .HasMaxLength(50);
    }
}
