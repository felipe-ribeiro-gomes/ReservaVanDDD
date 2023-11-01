namespace ReservaVan.Motorista.Domain.Entities
{
    public class Viagem : EntityBase<Guid>
    {
        public decimal Valor { get; set; }
        public DateTime DataHoraPartida { get; set; }

        public Usuario Usuario { get; set; }
        public Automovel Automovel { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
