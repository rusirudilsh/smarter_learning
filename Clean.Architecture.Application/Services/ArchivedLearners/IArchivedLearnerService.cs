using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Services.ArchivedLearners
{
    public interface IArchivedLearnerService
    {
        Task<Learner> GetArchivedLearnerFromArchive(int learnerId);
    }
}
