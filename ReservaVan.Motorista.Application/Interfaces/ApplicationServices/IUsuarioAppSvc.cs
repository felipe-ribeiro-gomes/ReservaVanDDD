using ReservaVan.Motorista.Application.DTOs;

namespace ReservaVan.Motorista.Application.Interfaces.ApplicationServices;

public interface IUsuarioAppSvc
{
    Task<RegisterUsuarioResponse> Register(RegisterUsuarioRequest request);
}