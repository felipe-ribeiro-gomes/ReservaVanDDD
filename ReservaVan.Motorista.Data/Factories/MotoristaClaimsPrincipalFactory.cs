using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ReservaVan.Motorista.Domain.Entities;
using System.Security.Claims;

namespace ReservaVan.Motorista.Data.Factories;

public class MotoristaClaimsPrincipalFactory : UserClaimsPrincipalFactory<Usuario, Grupo>
{
    public MotoristaClaimsPrincipalFactory(
        UserManager<Usuario> userManager
        , RoleManager<Grupo> roleManager
        , IOptions<IdentityOptions> optionsAccessor
    ) : base(userManager, roleManager, optionsAccessor) { }

    public async override Task<ClaimsPrincipal> CreateAsync(Usuario usuario)
    {
        var principal = await base.CreateAsync(usuario);
        
        if (!string.IsNullOrWhiteSpace(usuario.Nome))
        {
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] 
            {
                new Claim(ClaimTypes.GivenName, usuario.Nome)
            });
        }

        if (!string.IsNullOrWhiteSpace(usuario.Sobrenome))
        {
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] 
            {
                new Claim(ClaimTypes.Surname, usuario.Sobrenome),
            });
        }

        ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim(type: "Ativo", value: usuario.Ativo ? "true" : "false"),
            }
        );

        return principal;
    }
}
