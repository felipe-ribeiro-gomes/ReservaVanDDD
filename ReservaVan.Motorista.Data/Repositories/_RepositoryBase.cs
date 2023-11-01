using Microsoft.EntityFrameworkCore;
using ReservaVan.Motorista.Domain.Entities;
using ReservaVan.Motorista.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace ReservaVan.Motorista.Data.Repositories;

public class RepositoryBase<TEntity, T> : IRepositoryBase<TEntity, T> where TEntity : EntityBase<T>
{
    internal MotoristaDbContext _context;
    internal DbSet<TEntity> _dbSet;

    public RepositoryBase(MotoristaDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = ""
    )
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            query = query.Include(includeProperty);

        if (orderBy != null)
            return orderBy(query).ToList();
        else
            return query.ToList();
    }

    public virtual TEntity GetById(T id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Insert(TEntity entity)
    {
        entity.CriadoPor = "";
        entity.CriadoEm = DateTime.UtcNow;
        _dbSet.Add(entity);
    }

    public virtual void Delete(T id)
    {
        TEntity entityToDelete = _dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        entityToDelete.EditadoPor = "";
        entityToDelete.EditadoEm = DateTime.UtcNow;
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        entityToUpdate.EditadoPor = "";
        entityToUpdate.EditadoEm = DateTime.UtcNow;
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}