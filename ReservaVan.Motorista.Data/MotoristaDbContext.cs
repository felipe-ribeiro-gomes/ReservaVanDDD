using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PassageiroVan.Web.Motorista.Data.Configurations;
using ReservaVan.Motorista.Data.Configurations;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Data;

public class MotoristaDbContext : IdentityDbContext<Usuario, Grupo, string, UsuarioClaim, GrupoUsuario, UsuarioLogin, GrupoClaim, UsuarioToken>
{
    public MotoristaDbContext(DbContextOptions<MotoristaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Automovel> Automoveis { get; set; }
    public DbSet<Viagem> Viagens { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Passageiro> Passageiros { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UsuarioConfiguration());
        builder.ApplyConfiguration(new UsuarioClaimConfiguration());
        builder.ApplyConfiguration(new UsuarioLoginConfiguration());
        builder.ApplyConfiguration(new UsuarioTokenConfiguration());
        builder.ApplyConfiguration(new GrupoConfiguration());
        builder.ApplyConfiguration(new GrupoClaimConfiguration());
        builder.ApplyConfiguration(new GrupoUsuarioConfiguration());
        builder.ApplyConfiguration(new AutomovelConfiguration());
        builder.ApplyConfiguration(new ViagemConfiguration());
        builder.ApplyConfiguration(new ReservaConfiguration());
        builder.ApplyConfiguration(new PassageiroConfiguration());
    }
}