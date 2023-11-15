using Microsoft.AspNetCore.Mvc;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;
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
            return View(model);

        model.ReturnUrl ??= Url.Content("~/");
        model.ExternalLogins = (await _unitOfWork.SignInRepository.GetExternalAuthenticationSchemesAsync()).ToList();

        var user = new Usuario();
        user.Email = model.Email;
        user.UserName = model.Email;
        user.Nome = model.Nome ?? "";
        user.Sobrenome = model.Sobrenome ?? "";
        user.DataNascimento = model.DataNascimento!.Value;

        var result = await _unitOfWork.UsuarioRepository.Register(user, model.Password!);
        if (!result.Succeeded)
        {
            return View(model);
        }

        await _unitOfWork.SignInRepository.SignInAsync(user, isPersistent: false);

        return LocalRedirect(model.ReturnUrl);

        //if (ModelState.IsValid)
        //{


        //    if (result.Succeeded)
        //    {
        //        _logger.LogInformation("User created a new account with password.");

        //        var userId = await _unitOfWork.UsuarioRepository.GetUserIdAsync(user);
        //        var code = await _unitOfWork.UsuarioRepository.GenerateEmailConfirmationTokenAsync(user);
        //        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //        var callbackUrl = Url.Page(
        //            "/Motorista/ConfirmeEmail",
        //            pageHandler: null,
        //            values: new { area = "Identity", userId = userId, code = code, returnUrl = model.ReturnUrl },
        //            protocol: Request.Scheme);

        //        await _emailSender.SendEmailAsync(model.Email ?? "", "Confirm your email",
        //            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl ?? "")}'>clicking here</a>.");

        //        if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //        {
        //            return RedirectToPage("RegisterConfirmation", new { email = model.Email, returnUrl = model.ReturnUrl });
        //        }
        //        else
        //        {
        //            await _unitOfWork.SignInRepository.SignInAsync(user, isPersistent: false);
        //            return LocalRedirect(model.ReturnUrl);
        //        }
        //    }
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //}
    }
}

public partial class RegistreController
{
    private readonly IUnitOfWork _unitOfWork;
    //private readonly SignInManager<Usuario> _signInManager;
    //private readonly UserManager<Usuario> _userManager;
    //private readonly IUserStore<Usuario> _userStore;
    //private readonly IUserEmailStore<Usuario> _emailStore;
    private readonly ILogger<RegistreController> _logger;
    //private readonly IEmailSender _emailSender;

    public RegistreController(
        IUnitOfWork unitOfWork,
        //UserManager<Usuario> userManager,
        //IUserStore<Usuario> userStore,
        //SignInManager<Usuario> signInManager,
        ILogger<RegistreController> logger
        //IEmailSender emailSender
    )
    {
        _unitOfWork = unitOfWork;
        //_userManager = userManager;
        //_userStore = userStore;
        //_emailStore = GetEmailStore();
        //_signInManager = signInManager;
        _logger = logger;
        //_emailSender = emailSender;
    }
}