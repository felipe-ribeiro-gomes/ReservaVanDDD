using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Application.DTOs;
using ReservaVan.Motorista.Application.Interfaces.ApplicationServices;
using ReservaVan.Motorista.Web.Models.ViewModels;

namespace ReservaVan.Motorista.Web.Controllers;

public partial class RegistreController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new RegistreViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegistreViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Errors = ModelState.Keys.SelectMany(key => ModelState[key]!.Errors.Select(x => $"{key}: {x.ErrorMessage}"));
            return View(model);
        }

        model.ReturnUrl ??= Url.Content("~/");
        //model.ExternalLogins = (await _unitOfWork.SignInRepository.GetExternalAuthenticationSchemesAsync()).ToList();

        var user = new RegisterUsuarioRequest();
        user.Email = model.Email!;
        user.Password = model.Password!;
        user.Nome = model.Nome!;
        user.Sobrenome = model.Sobrenome!;
        user.DataNascimento = model.DataNascimento!.Value;

        var result = await _usuarioAppSvc.Register(user);
        if (result.Errors.Any())
        {
            model.Errors = result.Errors.ToList();
            return View(model);
        }

        return LocalRedirect(model.ReturnUrl);
    }
}

public partial class RegistreController
{
    private readonly IUsuarioAppSvc _usuarioAppSvc;
    private readonly ILogger<RegistreController> _logger;

    public RegistreController(
        IUsuarioAppSvc usuarioAppSvc,
        ILogger<RegistreController> logger
    )
    {
        _usuarioAppSvc = usuarioAppSvc;
        _logger = logger;
    }
}