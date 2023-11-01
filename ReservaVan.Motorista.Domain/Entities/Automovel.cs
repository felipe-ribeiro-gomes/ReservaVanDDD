namespace ReservaVan.Motorista.Domain.Entities;

public class Automovel : EntityBase<Guid>
{
    public Automovel()
    {
        Viagens = new HashSet<Viagem>();
    }

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public string Placa { get; set; }
    public int QtdVaga { get; set; }

    public Usuario Usuario { get; set; }
    public ICollection<Viagem> Viagens { get; set; }
}
