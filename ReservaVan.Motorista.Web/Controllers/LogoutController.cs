using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Web.Controllers;

public partial class LogoutController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await _signInManager.SignOutAsync();
        
        return RedirectToAction("Index", "Home");
    }
}

public partial class LogoutController
{
    private readonly SignInManager<Usuario> _signInManager;
    private readonly ILogger<LogoutController> _logger;

    public LogoutController(
        SignInManager<Usuario> signInManager,
        ILogger<LogoutController> logger
    )
    {
        _signInManager = signInManager;
        _logger = logger;
    }
}