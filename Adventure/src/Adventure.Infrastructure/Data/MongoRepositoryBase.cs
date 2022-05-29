using System.Linq.Expressions;
using Adventure.Infrastructure.Interfaces;
using Adventure.SharedKernel.Interfaces;
using Adventure.Infrastructure.Interfaces;
using Adventure.SharedKernel.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Adventure.Infrastructure.Data;

public abstract class MongoRepositoryBase<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
  private readonly IMongoCollection<T> _adventureCollection;

  public MongoRepositoryBase(IOptions<AdventureStoreDatabaseSettings> adventureDatabaseSettings)
  {
    if (adventureDatabaseSettings == null)
    {
      throw new ArgumentNullException(nameof(adventureDatabaseSettings));
    }

    var adventureDatabaseSettings1 = adventureDatabaseSettings;
    var mongoClient = new MongoClient(adventureDatabaseSettings1.Value.ConnectionString);

    var mongoDatabase = mongoClient.GetDatabase(adventureDatabaseSettings1.Value.DatabaseName);
    _adventureCollection = mongoDatabase.GetCollection<T>(typeof(T).Name);
  }

  public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
  {
    await _adventureCollection.InsertOneAsync(entity, null, cancellationToken);

    return entity;
  }

  public async Task UpdateAsync<TId>(TId? id, T entity, CancellationToken cancellationToken = default)
    where TId : notnull
  {
    await _adventureCollection.ReplaceOneAsync(x => x.Id == id.ToString(), entity);
  }

  public async Task DeleteAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
  {
    await _adventureCollection.DeleteOneAsync(d => d.Id == id.ToString(), cancellationToken);
  }

  public virtual async Task<T?> GetByIdAsync<TId>(TId? id, CancellationToken cancellationToken = default)
    where TId : notnull
  {
    return await _adventureCollection.Find(x => x.Id == id.ToString())
      .FirstOrDefaultAsync(cancellationToken);
  }

  public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
  {
    return await _adventureCollection.Find(_ => true).ToListAsync(cancellationToken);
  }

  public virtual async Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
  {
    return await _adventureCollection.Find(_ => true).ToListAsync(cancellationToken);
  }
}
