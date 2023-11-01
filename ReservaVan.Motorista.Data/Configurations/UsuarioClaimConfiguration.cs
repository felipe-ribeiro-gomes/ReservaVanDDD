using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class UsuarioClaimConfiguration : IEntityTypeConfiguration<UsuarioClaim>
{
    public void Configure(EntityTypeBuilder<UsuarioClaim> builder)
    {
        builder.ToTable("UsuarioClaim", "Motorista");
    }
}
