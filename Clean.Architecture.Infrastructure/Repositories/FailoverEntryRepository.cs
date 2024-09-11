using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Domain.Entities;


namespace Clean.Architecture.Infrastructure.Repositories
{
    public class FailoverEntryRepository: BaseRepository<FailoverEntry>, IFailoverEntryRepository
    {
        private List<FailoverEntry> _failoverEntryList;

        public FailoverEntryRepository()
        {
            _failoverEntryList = new List<FailoverEntry>([new FailoverEntry { Id = 1, DateTime = DateTime.Now }, 
                                                          new FailoverEntry { Id = 2, DateTime = DateTime.Now.AddMinutes(-5) },
                                                          new FailoverEntry { Id = 2, DateTime = DateTime.Now.AddMinutes(-10) }]);
        }

        public async new Task<IReadOnlyList<FailoverEntry>> ListAllAsync()
        {
            await Task.Delay(1000);
            return _failoverEntryList;
        }
    }
}
