using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Infrastructure.ServiceClient
{
    public class ArchivedDataService : IArchivedDataService
    {
        private List<Learner> _learnerList;
        public ArchivedDataService()
        {
            _learnerList = new List<Learner>([new Learner  { Id = 2, Name = "Dilshan" }]);
        }
        public async Task<Learner> GetArchivedLearner(int learnerId)
        {
            await Task.Delay(1000);
            return _learnerList.FirstOrDefault(learner => learner?.Id == learnerId)!;
        }
    }
}
