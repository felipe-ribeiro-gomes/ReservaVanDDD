using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> FindByIdAsync(string userId);
}