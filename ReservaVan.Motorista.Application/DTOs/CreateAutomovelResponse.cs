namespace ReservaVan.Motorista.Application.DTOs;

public class CreateAutomovelResponse
{
    public string UsuarioId { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public string Placa { get; set; }
    public int QtdVaga { get; set; }
}