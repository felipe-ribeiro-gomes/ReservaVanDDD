using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;
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

        //var usuario = await _userManager.FindByEmailAsync(model.Email);
        var usuario = await _unitOfWork.UsuarioRepository.FindByEmailAsync(model.Email);
        if (usuario == null)
        {
            model.ModelStateErrors.Add("E-mail não existe cadastrado ou senha está incorreta");

            return View(model);
        }

        //var senhaEstaCorreta = await _userManager.CheckPasswordAsync(usuario, model.Password);
        var senhaEstaCorreta = await _unitOfWork.UsuarioRepository.CheckPasswordAsync(usuario, model.Password);
        if (!senhaEstaCorreta)
        {
            model.ModelStateErrors.Add("E-mail não existe cadastrado ou senha está incorreta");

            return View(model);
        }

        //await _signInManager.SignInAsync(usuario, false);
        await _unitOfWork.SignInRepository.SignInAsync(usuario, false);

        return LocalRedirect(model.ReturnUrl);
    }
}

public partial class LoginController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<LoginController> _logger;

    public LoginController(
        IUnitOfWork unitOfWork,
        ILogger<LoginController> logger
    )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
}