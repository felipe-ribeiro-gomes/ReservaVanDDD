using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class UsuarioLoginConfiguration : IEntityTypeConfiguration<UsuarioLogin>
{
    public void Configure(EntityTypeBuilder<UsuarioLogin> builder)
    {
        builder.ToTable("UsuarioLogin", "Motorista");

        builder.HasKey("LoginProvider", "ProviderKey");
    }
}
