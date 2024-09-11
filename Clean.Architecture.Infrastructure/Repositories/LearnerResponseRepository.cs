using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Infrastructure.Repositories
{
    public class LearnerResponseRepository : BaseRepository<LearnerResponse>, ILearnerResponseRepository
    {
        private List<LearnerResponse> _learnerList;

        public LearnerResponseRepository()
        {
            _learnerList = new List<LearnerResponse>([new LearnerResponse { IsArchived = false, Learner = new Learner { Id = 1, Name = "Rusiru" } }]);
        }
        public async Task<LearnerResponse> GetLearnerById(int id)
        {
            await Task.Delay(1000);
            return _learnerList.FirstOrDefault(learner => learner?.Learner?.Id == id && !learner.IsArchived)!;
        }
    }
}
