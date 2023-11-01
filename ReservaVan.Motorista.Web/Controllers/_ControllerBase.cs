using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Web.Models.ViewModels;
using System.Diagnostics;

namespace ReservaVan.Motorista.Web.Controllers;

public class ControllerBase : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
