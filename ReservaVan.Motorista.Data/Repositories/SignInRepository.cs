using Microsoft.AspNetCore.Identity;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;
using System.Security.Claims;
using ReservaVan.Motorista.Domain.Types;
using ReservaVan.Motorista.Data.Extensions;

namespace ReservaVan.Motorista.Data.Repositories;

public class SignInRepository : ISignInRepository
{
    MotoristaDbContext _context;
    SignInManager<Usuario> _signInManager;

    public SignInRepository(MotoristaDbContext context, SignInManager<Usuario> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }

    public async Task SignInAsync(Usuario user, bool isPersistent, string? authenticationMethod = null) => await _signInManager.SignInAsync(user, isPersistent, authenticationMethod);

    public async Task SignOutAsync() => await _signInManager.SignOutAsync();

    public async Task<IEnumerable<AuthScheme>> GetExternalAuthenticationSchemesAsync() => (await _signInManager.GetExternalAuthenticationSchemesAsync()).Select(s => s.ToAuthScheme());

    public bool IsSignedIn(ClaimsPrincipal principal) => _signInManager.IsSignedIn(principal);
}
