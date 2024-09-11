using Microsoft.Extensions.Options;
using Moq;
using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Application.Models;
using Clean.Architecture.Application.Services.ActiveLearners;
using Clean.Architecture.Application.Services.DateTimes;
using Clean.Architecture.Domain.Entities;
using Clean.Architecture.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Clean.Architecture.UnitTest.Learners
{
    public class GetActiveLearnerTest
    {
        private readonly Mock<ILearnerDataAccess> _mockLearnerDataAccess;
        private readonly Mock<IFailoverEntryRepository> _mockFailoverEntryRepository;
        private readonly Mock<ILearnerResponseRepository> _mockLearnerResponseRepository;
        private readonly Mock<IDateTimeService> _mockDateTimeService;

        public Mock<IOptions<FailoverModeSettings>> FailoverModeSettings { get; }

        public GetActiveLearnerTest()
        {
            _mockLearnerDataAccess = ServiceMocks.GetLearnerDataAccess(1);
            _mockDateTimeService = ServiceMocks.GetDateTimeService();
            _mockFailoverEntryRepository = RepositoryMocks.GetFailoverEntryRepository();
            _mockLearnerResponseRepository = RepositoryMocks.GetLearnerResponseRepository(1);
            FailoverModeSettings = ConfigMock.GetFailoverModeSettings();
        }


        [Fact]
        public async Task GetLearnerTest()
        {
           var learnerService = new LearnerService(_mockLearnerDataAccess.Object, 
                                                   _mockFailoverEntryRepository.Object, 
                                                   _mockLearnerResponseRepository.Object, 
                                                   _mockDateTimeService.Object, 
                                                   FailoverModeSettings.Object);
           var result = await learnerService.GetLearner(1);

           result.ShouldBeOfType<Learner>();
        }
    }
}
