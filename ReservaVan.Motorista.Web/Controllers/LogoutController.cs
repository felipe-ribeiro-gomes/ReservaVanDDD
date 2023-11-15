using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Web.Controllers;

public partial class LogoutController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await _unitOfWork.SignInRepository.SignOutAsync();
        
        return RedirectToAction("Index", "Home");
    }
}

public partial class LogoutController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<LogoutController> _logger;

    public LogoutController(
        IUnitOfWork unitOfWork,
        ILogger<LogoutController> logger
    )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
}