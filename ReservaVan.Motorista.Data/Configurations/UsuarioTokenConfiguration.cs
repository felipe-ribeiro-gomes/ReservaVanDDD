using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class UsuarioTokenConfiguration : IEntityTypeConfiguration<UsuarioToken>
{
    public void Configure(EntityTypeBuilder<UsuarioToken> builder)
    {
        builder.ToTable("UsuarioToken", "Motorista");

        builder.HasKey("UserId", "LoginProvider", "Name");
    }
}
