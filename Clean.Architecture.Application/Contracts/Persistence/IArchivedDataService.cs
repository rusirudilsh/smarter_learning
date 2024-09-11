using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Contracts.Persistence
{
    public interface IArchivedDataService
    {
        Task<Learner> GetArchivedLearner(int learnerId);
    }
}
