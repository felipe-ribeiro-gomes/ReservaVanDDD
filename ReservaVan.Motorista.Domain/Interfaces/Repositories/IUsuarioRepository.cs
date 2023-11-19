using ReservaVan.Motorista.Domain.Types;
using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> FindByIdAsync(string userId);
    Usuario? FirstOrDefault(string userId);
    Task<Usuario?> FindByEmailAsync(string email);
    Task<string> GetUserIdAsync(Usuario user);
    Task<bool> CheckPasswordAsync(Usuario user, string password);
    Task<UsuarioResult> Create(Usuario user);
    Task<UsuarioResult> Register(Usuario user, string password);
    Task<string> GenerateEmailConfirmationTokenAsync(Usuario user);
}