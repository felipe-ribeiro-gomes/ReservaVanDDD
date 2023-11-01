using Microsoft.AspNetCore.Mvc;

namespace ReservaVan.Motorista.Web.Controllers
{
    public class VansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
