using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Contracts.Persistence
{
    public interface IFailoverEntryRepository: IAsyncRepository<FailoverEntry>
    {
    }
}
