using Microsoft.AspNetCore.Identity;
using ReservaVan.Motorista.Domain.Types;

namespace ReservaVan.Motorista.Data.Extensions
{
    public static class IdentityResultExtension
    {
        public static UsuarioResult ToUsuarioResult(this IdentityResult identityResult)
        {
            var toUsuarioError = (IdentityError identityError) => {
                return new UsuarioError
                {
                    Code = identityError.Code,
                    Description = identityError.Description,
                };
            };

            if (identityResult.Succeeded)
                return UsuarioResult.Success;
            else
                return UsuarioResult.Failed(identityResult.Errors.Select(s => toUsuarioError(s)).ToArray());
        }
    }
}
