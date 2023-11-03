using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Application.Interfaces.ApplicationServices;

namespace ReservaVan.Motorista.Web.Controllers;

//[Authorize]
public partial class DadosPessoaisController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        _automovelAppSvc.Create(new Application.DTOs.CreateAutomovelRequest
        {
            Marca = "marca appsvc",
            Modelo = "modelo appsvc",
            Cor = "cor appsvc",
            Placa = "placa",
            QtdVaga = 15,
            UsuarioId = "90eba85e-7064-4ffe-a638-9e1c3d1713c7",
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