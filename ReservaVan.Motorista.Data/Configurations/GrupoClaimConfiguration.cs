using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class GrupoClaimConfiguration : IEntityTypeConfiguration<GrupoClaim>
{
    public void Configure(EntityTypeBuilder<GrupoClaim> builder)
    {
        builder.ToTable("GrupoClaim", "Motorista");
    }
}
