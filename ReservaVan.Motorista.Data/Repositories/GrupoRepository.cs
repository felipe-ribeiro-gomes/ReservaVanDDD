using Microsoft.AspNetCore.Identity;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Data.Repositories;

public class GrupoRepository : IGrupoRepository
{
    MotoristaDbContext _context;
    RoleManager<Grupo> _roleManager;

    public GrupoRepository(MotoristaDbContext context, RoleManager<Grupo> roleManager)
    {
        _context = context;
        _roleManager = roleManager;
    }
}
