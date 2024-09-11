using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Services.ActiveLearners
{
    public interface ILearnerService
    {
        Task<Learner?> GetLearner(int learnerId);
    }
}
