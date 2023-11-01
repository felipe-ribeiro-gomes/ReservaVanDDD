using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Web.Models.ViewModels;

namespace ReservaVan.Motorista.Web.Controllers;

public partial class LoginController : ControllerBase
{
    [HttpGet]
    public IActionResult Index(string returnUrl)
    {
        var model = new LoginViewModel();
        model.ReturnUrl = returnUrl;

        return View(model);
    }

    public async Task<IActionResult> Index(LoginViewModel model) 
    {
        model.ReturnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid)
        {
            model.ModelStateErrors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors, (x, y) => y.ErrorMessage)
                .ToList();

            return View(model);
        }

        var usuario = await _userManager.FindByEmailAsync(model.Email);
        if (usuario == null)
        {
            model.ModelStateErrors.Add("E-mail não existe cadastrado ou senha está incorreta");

            return View(model);
        }

        var senhaEstaCorreta = await _userManager.CheckPasswordAsync(usuario, model.Password);
        if (!senhaEstaCorreta)
        {
            model.ModelStateErrors.Add("E-mail não existe cadastrado ou senha está incorreta");

            return View(model);
        }

        await _signInManager.SignInAsync(usuario, false);

        return LocalRedirect(model.ReturnUrl);
    }
}

public partial class LoginController
{
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly ILogger<LoginController> _logger;

    public LoginController(
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager,
        ILogger<LoginController> logger
    )
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;
    }
}