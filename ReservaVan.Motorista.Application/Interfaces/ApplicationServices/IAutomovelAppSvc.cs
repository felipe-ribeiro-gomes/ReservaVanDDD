using ReservaVan.Motorista.Application.DTOs;

namespace ReservaVan.Motorista.Application.Interfaces.ApplicationServices;

public interface IAutomovelAppSvc
{
    Task<CreateAutomovelResponse> Create(CreateAutomovelRequest request);
}