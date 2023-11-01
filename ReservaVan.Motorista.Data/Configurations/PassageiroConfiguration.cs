using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace PassageiroVan.Web.Motorista.Data.Configurations;

public class PassageiroConfiguration : IEntityTypeConfiguration<Passageiro>
{
    public void Configure(EntityTypeBuilder<Passageiro> builder)
    {
        builder.ToTable("Passageiro", "Motorista");

        builder.Property(p => p.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Sobrenome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Ativo)
            .IsRequired();

        builder.Property(p => p.DataNascimento)
            .IsRequired();

        builder.Property(p => p.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasMany(p => p.Reservas)
            .WithOne(p => p.Passageiro);

        builder.Property(p => p.CriadoPor)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.CriadoEm)
            .IsRequired();

        builder.Property(p => p.EditadoPor)
            .HasMaxLength(50);
    }
}
