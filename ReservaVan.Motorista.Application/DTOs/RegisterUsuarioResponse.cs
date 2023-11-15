namespace ReservaVan.Motorista.Application.DTOs;

public class RegisterUsuarioResponse
{
    public Guid Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public string Sobrenome { get; set; } = default!;
    public DateTime DataNascimento { get; set; } = default!;

    public IEnumerable<string> Errors { get; set; } = new List<string>();
}