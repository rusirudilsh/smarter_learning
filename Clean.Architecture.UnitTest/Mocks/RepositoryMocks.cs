using Moq;
using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IFailoverEntryRepository> GetFailoverEntryRepository()
        {
            var failoverEntryList = new List<FailoverEntry>([new FailoverEntry { Id = 1, DateTime = DateTime.Now },
                                                          new FailoverEntry { Id = 2, DateTime = DateTime.Now.AddMinutes(-5) },
                                                          new FailoverEntry { Id = 2, DateTime = DateTime.Now.AddMinutes(-10) }]);

            var mockFailoverEntryRepository = new Mock<IFailoverEntryRepository>();
            mockFailoverEntryRepository.Setup(repository => repository.ListAllAsync()).ReturnsAsync(failoverEntryList);

            return mockFailoverEntryRepository;
        }

        public static Mock<ILearnerResponseRepository> GetLearnerResponseRepository(int learnerId)
        {
            var learnerList = new List<LearnerResponse>([new LearnerResponse { IsArchived = false, Learner = new Learner { Id = 1, Name = "Rusiru" } }]);

            var mockLearnerResponseRepository = new Mock<ILearnerResponseRepository>();
            mockLearnerResponseRepository.Setup(repository => repository.GetLearnerById(learnerId)).ReturnsAsync(learnerList.FirstOrDefault(learner => learner?.Learner?.Id == learnerId && !learner.IsArchived)!);

            return mockLearnerResponseRepository;
        }
    }
}
