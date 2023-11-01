using Microsoft.AspNetCore.Mvc;

namespace ReservaVan.Motorista.Web.Controllers;

public partial class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}

public partial class HomeController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
}