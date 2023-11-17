using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Core.Abstractions
{
    public interface IRepository<TEntity,T>
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        TEntity Get(T id);
        Task<TEntity> GetAsync(T id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "");
        IQueryable<TEntity> GetAll();
        void Remove(T id);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
