namespace Adventure.Infrastructure.Interfaces;

public interface IRepositoryBase<T> : IReadRepositoryBase<T> where T : class
{
  /// <summary>
  ///   Adds an entity in the database.
  /// </summary>
  /// <param name="entity">The entity to add.</param>
  /// <returns>
  ///   A task that represents the asynchronous operation.
  ///   The task result contains the <typeparamref name="T" />.
  /// </returns>
  Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

  /// <summary>
  ///   Updates an entity in the database
  /// </summary>
  /// <param name="entity">The entity to update.</param>
  /// <returns>A task that represents the asynchronous operation.</returns>
  Task UpdateAsync<TId>(TId id, T entity, CancellationToken cancellationToken = default);

  /// <summary>
  ///   Removes an entity in the database
  /// </summary>
  /// <param name="entity">The entity to delete.</param>
  /// <returns>A task that represents the asynchronous operation.</returns>
  Task DeleteAsync<TId>(TId id, CancellationToken cancellationToken = default);
}
