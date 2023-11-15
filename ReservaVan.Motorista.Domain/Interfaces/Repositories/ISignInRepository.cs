using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Types;
using System.Security.Claims;

namespace ReservaVan.Motorista.Domain.Interfaces.Repositories
{
    public interface ISignInRepository
    {
        Task SignInAsync(Usuario user, bool isPersistent, string? authenticationMethod = null);
        Task SignOutAsync();
        Task<IEnumerable<AuthScheme>> GetExternalAuthenticationSchemesAsync();
        bool IsSignedIn(ClaimsPrincipal principal);
    }
}