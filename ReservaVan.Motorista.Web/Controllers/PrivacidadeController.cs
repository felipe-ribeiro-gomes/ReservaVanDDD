using Microsoft.AspNetCore.Mvc;

namespace ReservaVan.Motorista.Web.Controllers;

public class PrivacidadeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
