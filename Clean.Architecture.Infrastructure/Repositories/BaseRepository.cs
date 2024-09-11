using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Domain.Common;

namespace Clean.Architecture.Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
