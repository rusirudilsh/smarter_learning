using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Infrastructure.ServiceClient
{
    public class LearnerDataAccess : ILearnerDataAccess
    {
        private List<LearnerResponse> _learnerList;
        public LearnerDataAccess()
        {
            _learnerList = new List<LearnerResponse>([new LearnerResponse { IsArchived = false, Learner = new Learner { Id = 1, Name = "Rusiru" } }]);
        }


        public async Task<LearnerResponse> LoadLearner(int learnerId)
        {
            await Task.Delay(1000);
            return _learnerList.FirstOrDefault(learner => learner?.Learner?.Id == learnerId && !learner.IsArchived)!;
        }
    }
}
