using MediatR;

namespace ReservaVan.Motorista.Application.DTOs;

public class RegisterUsuarioRequest : IRequest<RegisterUsuarioResponse>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public string Sobrenome { get; set; } = default!;
    public DateTime DataNascimento { get; set; } = default!;
}
