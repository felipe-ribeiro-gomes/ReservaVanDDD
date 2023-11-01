using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data.Configurations;

public class GrupoUsuarioConfiguration : IEntityTypeConfiguration<GrupoUsuario>
{
    public void Configure(EntityTypeBuilder<GrupoUsuario> builder)
    {
        builder.ToTable("GrupoUsuario", "Motorista");

        builder.HasKey("UserId", "RoleId");
    }
}
