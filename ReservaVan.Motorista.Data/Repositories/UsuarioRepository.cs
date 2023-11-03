using Microsoft.AspNetCore.Identity;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    MotoristaDbContext _context;
    UserManager<Usuario> _userManager;

    public UsuarioRepository(MotoristaDbContext context)
    {
        _context = context;
        _userManager = IServiceCollectionExtensions.UserManager;
    }

    public async Task<Usuario?> FindByIdAsync(string userId) => await _context.Users.FindAsync(userId);
}
