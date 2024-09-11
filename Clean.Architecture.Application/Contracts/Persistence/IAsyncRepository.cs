using Clean.Architecture.Domain.Common;

namespace Clean.Architecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
