using MediatR;
using ReservaVan.Motorista.Application.DTOs;
using ReservaVan.Motorista.Application.Interfaces.ApplicationServices;

namespace ReservaVan.Motorista.Application.ApplicationServices;

public class AutomovelAppSvc : IAutomovelAppSvc
{
    private readonly IMediator _mediator;

    public AutomovelAppSvc(IMediator mediator) => _mediator = mediator;

    public async Task<CreateAutomovelResponse> Create(CreateAutomovelRequest request) => await _mediator.Send(request);
}
