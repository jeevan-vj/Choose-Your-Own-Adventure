using Adventure.Infrastructure.Interfaces;
using Adventure.SharedKernel.Interfaces;
using Microsoft.Extensions.Options;

namespace Adventure.Infrastructure.Data;

public class MongoRepository<T> : MongoRepositoryBase<T>, IReadRepository<T>, IRepository<T>
  where T : class, IAggregateRoot
{
  public MongoRepository(IOptions<AdventureStoreDatabaseSettings> adventureDatabaseSettings) : base(
    adventureDatabaseSettings)
  {
  }
}
