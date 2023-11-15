using ReservaVan.Motorista.Domain.Entities;

namespace ReservaVan.Motorista.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ISignInRepository SignInRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IRepositoryBase<Automovel, Guid> AutomovelRepository { get; }
        IRepositoryBase<Viagem, Guid> ViagemRepository { get;  }
        IRepositoryBase<Reserva, Guid> ReservaRepository { get; }
        IRepositoryBase<Passageiro, Guid> PassageiroRepository { get; }
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
    }
}