using System.Linq.Expressions;

namespace Adventure.Infrastructure.Interfaces;

public interface IReadRepositoryBase<T> where T : class
  {
    Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default);

    Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
    Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    

    
  }
