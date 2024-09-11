using Microsoft.Extensions.Options;
using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Application.Models;
using Clean.Architecture.Application.Services.DateTimes;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Application.Services.ActiveLearners
{
    public class LearnerService : ILearnerService
    {
        private readonly ILearnerDataAccess _learnerDataAccess;
        private readonly IFailoverEntryRepository _failoverEntryRepository;
        private readonly ILearnerResponseRepository _learnerResponseRepository;
        private readonly IDateTimeService _dateTimeService;

        public FailoverModeSettings FailoverModeSettings { get;}

        public LearnerService(ILearnerDataAccess learnerDataAccess, 
            IFailoverEntryRepository failoverEntryRepository, 
            ILearnerResponseRepository learnerResponseRepository, 
            IDateTimeService dateTimeService, 
            IOptions<FailoverModeSettings> failoverModeSettings)
        {
            _learnerDataAccess = learnerDataAccess;
            _failoverEntryRepository = failoverEntryRepository;
            _learnerResponseRepository = learnerResponseRepository;
            _dateTimeService = dateTimeService;
            FailoverModeSettings = failoverModeSettings.Value;
        }

        public async Task<Learner?> GetLearner(int learnerId)
        {
            // TODO: needs refactoring to retrieve only the required records based on the failed requests count to check and frequency to check.
            var failoverEntries = await _failoverEntryRepository.ListAllAsync();
            var failedRequests = 0;
            var timePeriod = _dateTimeService.Now.AddMinutes(FailoverModeSettings.FrequencyToCheckInMinutes);

            foreach (var failoverEntry in failoverEntries)
            {
                if (failoverEntry.DateTime > timePeriod)
                {
                    failedRequests++;
                }
            }

            LearnerResponse? learnerResponse = null;

            if (failedRequests > FailoverModeSettings.NumberOfFailedRequestsToCheck && FailoverModeSettings.IsFailoverModeEnabled)
            {
                learnerResponse = await _learnerResponseRepository.GetLearnerById(learnerId);
            }
            else
            {
                learnerResponse = await _learnerDataAccess.LoadLearner(learnerId);

            }

            return learnerResponse != null ? learnerResponse?.Learner : null;
        }
    }
}
