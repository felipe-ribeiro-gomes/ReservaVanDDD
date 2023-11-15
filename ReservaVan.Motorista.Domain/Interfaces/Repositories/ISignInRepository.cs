using Microsoft.AspNetCore.Authentication;
using ReservaVan.Motorista.Domain.Entities;
using System.Security.Claims;

namespace ReservaVan.Motorista.Domain.Interfaces.Repositories
{
    public interface ISignInRepository
    {
        Task SignInAsync(Usuario user, bool isPersistent, string? authenticationMethod = null);
        Task SignOutAsync();
        Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        bool IsSignedIn(ClaimsPrincipal principal);
    }
}