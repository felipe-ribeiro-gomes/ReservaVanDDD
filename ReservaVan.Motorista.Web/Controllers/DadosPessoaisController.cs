using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Application.DTOs;
using ReservaVan.Motorista.Application.Interfaces.ApplicationServices;

namespace ReservaVan.Motorista.Web.Controllers;

[Authorize]
public partial class DadosPessoaisController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await _automovelAppSvc.Create(new CreateAutomovelRequest
        {
            Marca = "marca appsvc",
            Modelo = "modelo appsvc",
            Cor = "cor appsvc",
            Placa = "placa",
            QtdVaga = 15,
            UsuarioId = "d412240c-fe1a-47ba-8411-a2462b503666",
        });

        return View();
    }
}

public partial class DadosPessoaisController
{
    private readonly IAutomovelAppSvc _automovelAppSvc;

    public DadosPessoaisController(IAutomovelAppSvc automovelAppSvc)
    {
        _automovelAppSvc = automovelAppSvc;
    }
}