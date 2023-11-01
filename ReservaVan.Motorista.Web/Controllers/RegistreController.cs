using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using ReservaVan.Motorista.Web.Extensions;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Web.Models.ViewModels;
using System.Text;
using System.Text.Encodings.Web;

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
        model.ReturnUrl ??= Url.Content("~/");
        model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        if (ModelState.IsValid)
        {
            var user = CreateUser();
            user.Nome = model.Nome ?? "";
            user.Sobrenome = model.Sobrenome ?? "";
            user.DataNascimento = model.DataNascimento ?? default;
            user.Ativo = true;
            user.CriadoPor = _signInManager.IsSignedIn(User) ? User.Identity?.Id().ToString() ?? "" : "_anonymous_";
            user.CriadoEm = DateTime.UtcNow;

            await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, model.Password ?? "");

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Motorista/ConfirmeEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code, returnUrl = model.ReturnUrl },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(model.Email ?? "", "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl ?? "")}'>clicking here</a>.");

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return RedirectToPage("RegisterConfirmation", new { email = model.Email, returnUrl = model.ReturnUrl });
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(model.ReturnUrl);
                }
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If we got this far, something failed, redisplay form
        return View(model);
    }
}

public partial class RegistreController
{
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly IUserStore<Usuario> _userStore;
    private readonly IUserEmailStore<Usuario> _emailStore;
    private readonly ILogger<RegistreController> _logger;
    private readonly IEmailSender _emailSender;

    public RegistreController(
        UserManager<Usuario> userManager,
        IUserStore<Usuario> userStore,
        SignInManager<Usuario> signInManager,
        ILogger<RegistreController> logger,
        IEmailSender emailSender)
    {
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
        _signInManager = signInManager;
        _logger = logger;
        _emailSender = emailSender;
    }

    private Usuario CreateUser()
    {
        try
        {
            return Activator.CreateInstance<Usuario>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(Usuario)}'. " +
                $"Ensure that '{nameof(Usuario)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }

    private IUserEmailStore<Usuario> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<Usuario>)_userStore;
    }
}