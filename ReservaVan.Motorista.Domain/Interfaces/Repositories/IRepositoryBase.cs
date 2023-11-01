using ReservaVan.Motorista.Domain.Entities;
using System.Linq.Expressions;

namespace ReservaVan.Motorista.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, T> where TEntity : EntityBase<T>
    {
        void Delete(T id);
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetById(T id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}