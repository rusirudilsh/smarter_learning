using Moq;
using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Application.Services.DateTimes;
using Clean.Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.UnitTest.Mocks
{
    public class ServiceMocks
    {
        public static Mock<ILearnerDataAccess> GetLearnerDataAccess(int learnerId)
        {
            var learnerList = new List<LearnerResponse>([new LearnerResponse { IsArchived = false, Learner = new Learner { Id = 1, Name = "Rusiru" } }]);

            var mockLearnerDataAccess = new Mock<ILearnerDataAccess>();
            mockLearnerDataAccess.Setup(service => service.LoadLearner(learnerId)).ReturnsAsync(learnerList.FirstOrDefault(learner => learner?.Learner?.Id == learnerId && !learner.IsArchived)!);

            return mockLearnerDataAccess;
        }

        public static Mock<IArchivedDataService> GetArchivedDataService(int learnerId)
        {
            var learnerList = new List<Learner>([new Learner { Id = 2, Name = "Dilshan" }]);

            var mockArchivedDataServic = new Mock<IArchivedDataService>();
            mockArchivedDataServic.Setup(service => service.GetArchivedLearner(learnerId)).ReturnsAsync(learnerList.FirstOrDefault(learner => learner?.Id == learnerId)!);

            return mockArchivedDataServic;
        }

        public static Mock<IDateTimeService> GetDateTimeService()
        {
            var mockDateTimeService = new Mock<IDateTimeService>();
            mockDateTimeService.Setup(service => service.Now).Returns(DateTime.Now);

            return mockDateTimeService;
        }
    }
}
