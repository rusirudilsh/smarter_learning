using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Contracts.Persistence
{
    public interface ILearnerResponseRepository: IAsyncRepository<LearnerResponse>
    {
        Task<LearnerResponse> GetLearnerById(int id);
    }
}
