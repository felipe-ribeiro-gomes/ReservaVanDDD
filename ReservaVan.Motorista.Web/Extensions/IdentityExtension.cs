using System.Security.Claims;
using System.Security.Principal;

namespace ReservaVan.Motorista.Web.Extensions;

public static class IdentityExtension
{
    public static Guid? Id(this IIdentity identity)
    {
        var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null)
            return null;

        return (Guid?)new Guid(claim.Value);
    }

    public static string? Nome(this IIdentity identity)
    {
        var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.GivenName);
        if (claim == null)
            return null;

        return claim.Value;
    }

    public static string? Sobrenome(this IIdentity identity)
    {
        var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Surname);
        if (claim == null)
            return null;

        return claim.Value;
    }

    public static bool Ativo(this IIdentity identity)
    {
        var claim = ((ClaimsIdentity)identity).FindFirst("Ativo");
        if (claim == null)
            return false;

        return Convert.ToBoolean(claim.Value);
    }
}