using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void UpdateInclude(TEntity entity, params string[] modifiedProperties);
        IQueryable<TEntity> GetAll(CancellationToken cancellationToken);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
        void Delete(TEntity entity);
        Task<bool> DoesEntityExistAsync(int id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
