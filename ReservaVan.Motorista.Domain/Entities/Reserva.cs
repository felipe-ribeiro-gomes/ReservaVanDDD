namespace ReservaVan.Motorista.Domain.Entities
{
    public class Reserva : EntityBase<Guid>
    {
        public int Posicao { get; set; }
        public int FormaPagamento { get; set; }
        public bool EstaPago { get; set; }
        public string? Observacao { get; set; }

        public Viagem Viagem { get; set; }
        public Passageiro Passageiro { get; set; }
    }
}
