using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Contracts.Persistence
{
    public interface ILearnerDataAccess
    {
        Task<LearnerResponse> LoadLearner(int learnerId);
    }
}
