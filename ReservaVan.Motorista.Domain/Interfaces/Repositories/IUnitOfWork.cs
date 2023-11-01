using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<Automovel, Guid> AutomovelRepository { get; }
        IRepositoryBase<Viagem, Guid> ViagemRepository { get;  }
        IRepositoryBase<Reserva, Guid> ReservaRepository { get; }
        IRepositoryBase<Passageiro, Guid> PassageiroRepository { get; }
        void Save();
    }
}