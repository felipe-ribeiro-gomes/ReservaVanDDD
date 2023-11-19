using Microsoft.AspNetCore.Identity;
using ReservaVan.Motorista.Data.Extensions;
using ReservaVan.Motorista.Domain.Types;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private MotoristaDbContext _context;
    private UserManager<Usuario> _userManager;
    private IUserStore<Usuario> _userStore;
    private IUserEmailStore<Usuario> _emailStore;

    public UsuarioRepository(MotoristaDbContext context, UserManager<Usuario> userManager, IUserStore<Usuario> userStore)
    {
        _context = context;
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = userManager.SupportsUserEmail ? (IUserEmailStore<Usuario>)userStore : null!;
    }

    public async Task<Usuario?> FindByIdAsync(string userId) => await _userManager.FindByIdAsync(userId);

    public Usuario? FirstOrDefault(string userId) => _context.Users.FirstOrDefault(q => q.Id == userId);

    public async Task<Usuario?> FindByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);

    public async Task<string> GetUserIdAsync(Usuario user) => await _userManager.GetUserIdAsync(user);

    public async Task<bool> CheckPasswordAsync(Usuario user, string password) => await _userManager.CheckPasswordAsync(user, password);

    public async Task<UsuarioResult> Create(Usuario user) => (await _userManager.CreateAsync(user)).ToUsuarioResult();

    public async Task<UsuarioResult> Register(Usuario user, string password)
    {
        user.Ativo = true;
        user.CriadoPor = "_anonymous_";
        user.CriadoEm = DateTime.Now;

        await _userStore.SetUserNameAsync(user, user.UserName, CancellationToken.None);
        
        if (_emailStore != null)
            await _emailStore.SetEmailAsync(user, user.Email, CancellationToken.None);

        var result = await _userManager.CreateAsync(user, password ?? "");

        if (!result.Succeeded)
            return IdentityResult.Failed(result.Errors.ToArray()).ToUsuarioResult();

        return UsuarioResult.Success;

        //    if (result.Succeeded)
        //    {
        //        _logger.LogInformation("User created a new account with password.");

        //        var userId = await _userManager.GetUserIdAsync(user);
        //        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //        var callbackUrl = Url.Page(
        //            "/Motorista/ConfirmeEmail",
        //        pageHandler: null,
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

    public async Task<string> GenerateEmailConfirmationTokenAsync(Usuario user) => await _userManager.GenerateEmailConfirmationTokenAsync(user);
}