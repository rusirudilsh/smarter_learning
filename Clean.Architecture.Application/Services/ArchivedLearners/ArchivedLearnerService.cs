using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Services.ArchivedLearners
{
    public class ArchivedLearnerService : IArchivedLearnerService
    {
        private readonly IArchivedDataService _archivedDataService;

        public ArchivedLearnerService(IArchivedDataService archivedDataService)
        {
            _archivedDataService = archivedDataService;
        }

        public async Task<Learner> GetArchivedLearnerFromArchive(int learnerId)
        {
            var archivedLearner = await _archivedDataService.GetArchivedLearner(learnerId);
            return archivedLearner;
        }
    }
}
