namespace ReservaVan.Motorista.Domain.Entities;

public class AssociationBase
{
    public string CriadoPor { get; set; }
    public DateTime CriadoEm { get; set; }
    public string? EditadoPor { get; set; }
    public DateTime? EditadoEm { get; set; }
}
