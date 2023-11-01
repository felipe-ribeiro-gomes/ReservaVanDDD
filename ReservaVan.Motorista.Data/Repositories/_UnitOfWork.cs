using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MotoristaDbContext _context;
    private readonly IRepositoryBase<Automovel, Guid> _automovelRepository;
    private readonly IRepositoryBase<Viagem, Guid> _viagemRepository;
    private readonly IRepositoryBase<Reserva, Guid> _reservaRepository;
    private readonly IRepositoryBase<Passageiro, Guid> _passageiroRepository;
    private bool disposed = false;

    public UnitOfWork(
        MotoristaDbContext context,
        IRepositoryBase<Automovel, Guid> automovelRepository,
        IRepositoryBase<Viagem, Guid> viagemRepository,
        IRepositoryBase<Reserva, Guid> reservaRepository,
        IRepositoryBase<Passageiro, Guid> passageiroRepository

    )
    {
        _context = context;

        _automovelRepository = automovelRepository;
        _viagemRepository = viagemRepository;
        _reservaRepository = reservaRepository;
        _passageiroRepository = passageiroRepository;
    }

    public IRepositoryBase<Automovel, Guid> AutomovelRepository { get => _automovelRepository; }
    public IRepositoryBase<Viagem, Guid> ViagemRepository { get => _viagemRepository; }
    public IRepositoryBase<Reserva, Guid> ReservaRepository { get => _reservaRepository; }
    public IRepositoryBase<Passageiro, Guid> PassageiroRepository { get => _passageiroRepository; }

    public void Save() => _context.SaveChanges();

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}