using Microsoft.Extensions.DependencyInjection;
using ReservaVan.Motorista.Application.ApplicationServices;
using ReservaVan.Motorista.Application.Interfaces.ApplicationServices;

namespace ReservaVan.Motorista.Application;

public static class IServiceCollectionExtensions
{
	public static void AddServicesFromApplication(this IServiceCollection services)
	{
        var loaded = AppDomain.CurrentDomain.Load("ReservaVan.Motorista.Application");

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(loaded));

        services.AddAutoMapper(loaded);

        services.AddScoped<IAutomovelAppSvc, AutomovelAppSvc>();
    }
}
