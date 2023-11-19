using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ReservaVan.Motorista.Application.ApplicationServices;
using ReservaVan.Motorista.Application.DTOs;

namespace ReservaVan.Motorista.Application.Tests.ApplicationServices;

[TestClass]
public class AutomovelAppSvcTest
{
    private readonly IServiceCollection _services;
    private readonly IServiceProvider _serviceProvider;
    private readonly IMediator _mediator;

    public AutomovelAppSvcTest()
    {
        _services = WebApplication.CreateBuilder().Services;
        _services.AddApplicationServices("Server=(localdb)\\mssqllocaldb;Database=ReservaVan;AttachDBFilename=D:\\Projects\\ReservaVan\\db\\ReservaVan.mdf;Trusted_Connection=True;MultipleActiveResultSets=true");
        _serviceProvider = _services.BuildServiceProvider();
        _mediator = new Mediator(_serviceProvider);
    }

    [TestMethod]
    public async Task criar_automovel()
    {
        var svc = new AutomovelAppSvc(_mediator);

        await svc.Create(new CreateAutomovelRequest
        {
            Marca = "marca appsvc",
            Modelo = "modelo appsvc",
            Cor = "cor appsvc",
            Placa = "placa",
            QtdVaga = 15,
            UsuarioId = "d412240c-fe1a-47ba-8411-a2462b503666",
            CriadoPor = "felipe",
            CriadoEm = DateTime.Now,
        });
    }
}