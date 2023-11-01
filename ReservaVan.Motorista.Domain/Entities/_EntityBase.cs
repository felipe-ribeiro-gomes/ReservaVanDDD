namespace ReservaVan.Motorista.Domain.Entities;

public class EntityBase<T>
{
    public EntityBase()
    {
        Id = Activator.CreateInstance<T>();
        CriadoPor = string.Empty;
    }

    public T Id { get; set; }

    public string CriadoPor { get; set; }
    public DateTime CriadoEm { get; set; }
    public string? EditadoPor { get; set; }
    public DateTime? EditadoEm { get; set; }
}
