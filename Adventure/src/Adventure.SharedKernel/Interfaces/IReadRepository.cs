using Adventure.SharedKernel.Interfaces;

namespace Adventure.Infrastructure.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
