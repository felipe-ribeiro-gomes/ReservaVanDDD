namespace ReservaVan.Motorista.Domain.Entities
{
    public class Passageiro : EntityBase<Guid>
    {
        public Passageiro()
        {
            Reservas = new HashSet<Reserva>();
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
