using Adventure.SharedKernel.Interfaces;

namespace Adventure.Infrastructure.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
