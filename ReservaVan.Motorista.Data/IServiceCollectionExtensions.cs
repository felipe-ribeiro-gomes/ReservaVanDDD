using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservaVan.Motorista.Data.Factories;
using ReservaVan.Motorista.Data.Repositories;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Data;

public static class IServiceCollectionExtensions
{
    public static UserManager<Usuario> UserManager;

	public static void AddIdentityDataFromInfra(this IServiceCollection services, string connectionString)
	{
        services
            .AddDatabaseDeveloperPageExceptionFilter()
            .AddDbContextFactory<MotoristaDbContext>(opt => opt.UseSqlServer(connectionString))
            .AddIdentity<Usuario, Grupo>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            })
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<MotoristaDbContext>()
            .AddClaimsPrincipalFactory<MotoristaClaimsPrincipalFactory>();

        UserManager = services.BuildServiceProvider().GetRequiredService<UserManager<Usuario>>();

        //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        //services.AddScoped<IRepositoryBase<Automovel, Guid>, RepositoryBase<Automovel, Guid>>();
        //services.AddScoped<IRepositoryBase<Viagem, Guid>, RepositoryBase<Viagem, Guid>>();
        //services.AddScoped<IRepositoryBase<Reserva, Guid>, RepositoryBase<Reserva, Guid>>();
        //services.AddScoped<IRepositoryBase<Passageiro, Guid>, RepositoryBase<Passageiro, Guid>>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //check this article about EF migrations "update-database". 
        //when dbcontext class name is used instead of connection string, the "update-database" return the following error:
        //System.ArgumentException: Format of the initialization string does not conform to specification starting at index 0
        //https://stackoverflow.com/questions/48486841/update-database-not-working-with-ef-core-2-0
    }
}
