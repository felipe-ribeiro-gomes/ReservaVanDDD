using Microsoft.AspNetCore.Identity;

namespace ReservaVan.Motorista.Domain.Entities;

public class Usuario : IdentityUser
{
    public Usuario()
    {
        Automoveis = new HashSet<Automovel>();
        Viagens = new HashSet<Viagem>();
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataNascimento { get; set; }
    
    public ICollection<Automovel> Automoveis { get; set; }
    public ICollection<Viagem> Viagens { get; set; }

    public string CriadoPor { get; set; }
    public DateTime CriadoEm { get; set; }
    public string? EditadoPor { get; set; }
    public DateTime? EditadoEm { get; set; }
}
