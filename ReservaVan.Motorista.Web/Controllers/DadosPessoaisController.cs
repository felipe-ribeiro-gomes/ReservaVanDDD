using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Web.Controllers;

[Authorize]
public partial class DadosPessoaisController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}

public partial class DadosPessoaisController
{
    private readonly IUnitOfWork _unitOfWork;

    public DadosPessoaisController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}