using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;

namespace ReservaVan.Motorista.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ISignInRepository _signInRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IGrupoRepository _grupoRepository;
    private readonly IRepositoryBase<Automovel, Guid> _automovelRepository;
    private readonly IRepositoryBase<Viagem, Guid> _viagemRepository;
    private readonly IRepositoryBase<Reserva, Guid> _reservaRepository;
    private readonly IRepositoryBase<Passageiro, Guid> _passageiroRepository;

    private readonly MotoristaDbContext _context;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<Grupo> _roleManager;
    private readonly IUserStore<Usuario> _userStore;
    private IDbContextTransaction? _transaction;

    public UnitOfWork()
    {
        _context = IServiceCollectionExtensions.ContextFactory.CreateDbContext();
        _signInManager = IServiceCollectionExtensions.SignInManager;
        _userManager = IServiceCollectionExtensions.UserManager;
        _roleManager = IServiceCollectionExtensions.RoleManager;
        _userStore = IServiceCollectionExtensions.UserStore;

        _signInRepository = new SignInRepository(_context, _signInManager);
        _usuarioRepository = new UsuarioRepository(_context, _userManager, _userStore);
        _grupoRepository = new GrupoRepository(_context, _roleManager);
        _automovelRepository = new RepositoryBase<Automovel, Guid>(_context);
        _viagemRepository = new RepositoryBase<Viagem, Guid>(_context);
        _reservaRepository = new RepositoryBase<Reserva, Guid>(_context);
        _passageiroRepository = new RepositoryBase<Passageiro, Guid>(_context);
    }

    public ISignInRepository SignInRepository { get => _signInRepository; }
    public IUsuarioRepository UsuarioRepository { get => _usuarioRepository; }
    public IGrupoRepository GrupoRepository { get => _grupoRepository; }
    public IRepositoryBase<Automovel, Guid> AutomovelRepository { get => _automovelRepository; }
    public IRepositoryBase<Viagem, Guid> ViagemRepository { get => _viagemRepository; }
    public IRepositoryBase<Reserva, Guid> ReservaRepository { get => _reservaRepository; }
    public IRepositoryBase<Passageiro, Guid> PassageiroRepository { get => _passageiroRepository; }

    public async Task BeginTransaction()
    {
        if (_transaction == null)
            _transaction = await _context.Database.BeginTransactionAsync();
        else
            throw new Exception("Já existe uma transação aberta na Unit Of Work");
    }

    public async Task CommitTransaction()
    {
        if (_transaction != null)
            await _transaction.CommitAsync();
        else
            throw new Exception("Não existe uma transação aberta na Unit Of Work");
    }

    public async Task RollbackTransaction()
    {
        if (_transaction != null)
            await _transaction.RollbackAsync();
        else
            throw new Exception("Não existe uma transação aberta na Unit Of Work");
    }
}