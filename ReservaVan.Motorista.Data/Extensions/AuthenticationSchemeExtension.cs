using Microsoft.AspNetCore.Authentication;
using ReservaVan.Motorista.Domain.Types;

namespace ReservaVan.Motorista.Data.Extensions
{
    public static class AuthenticationSchemeExtension
    {
        public static AuthScheme ToAuthScheme(this AuthenticationScheme authenticationScheme) => new AuthScheme(authenticationScheme.Name, authenticationScheme.DisplayName, authenticationScheme.HandlerType);
    }
}
