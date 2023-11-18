using Microsoft.Extensions.DependencyInjection;
using ReservaVan.Motorista.Application.ApplicationServices;
using ReservaVan.Motorista.Application.Interfaces.ApplicationServices;
using ReservaVan.Motorista.Data;

namespace ReservaVan.Motorista.Application;

public static class IServiceCollectionExtensions
{
	public static void AddApplicationServices(this IServiceCollection services, string dbConnectionString)
	{
        services.AddIdentityDataFromInfra(dbConnectionString);

        var loaded = AppDomain.CurrentDomain.Load("ReservaVan.Motorista.Application");

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(loaded));

        services.AddAutoMapper(loaded);

        services.AddScoped<IAutomovelAppSvc, AutomovelAppSvc>();
        services.AddScoped<IUsuarioAppSvc, UsuarioAppSvc>();
    }
}
