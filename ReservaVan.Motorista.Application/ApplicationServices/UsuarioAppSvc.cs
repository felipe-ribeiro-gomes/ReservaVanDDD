using MediatR;
using ReservaVan.Motorista.Application.DTOs;
using ReservaVan.Motorista.Application.Interfaces.ApplicationServices;

namespace ReservaVan.Motorista.Application.ApplicationServices;

public class UsuarioAppSvc : IUsuarioAppSvc
{
    private readonly IMediator _mediator;

    public UsuarioAppSvc(IMediator mediator) => _mediator = mediator;

    public async Task<RegisterUsuarioResponse> Register(RegisterUsuarioRequest request) => await _mediator.Send(request);
}