using Microsoft.Extensions.Options;
using Moq;
using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Application.Models;
using Clean.Architecture.Application.Services.ActiveLearners;
using Clean.Architecture.Application.Services.ArchivedLearners;
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
    public class GetArchivedLearnerTest
    {
        private readonly Mock<IArchivedDataService> _mockArchivedDataService;

        public GetArchivedLearnerTest()
        {
            _mockArchivedDataService = ServiceMocks.GetArchivedDataService(2);
        }


        [Fact]
        public async Task GetArchivedLearner()
        {
           var learnerService = new ArchivedLearnerService(_mockArchivedDataService.Object);
           var result = await learnerService.GetArchivedLearnerFromArchive(2);

           result.ShouldBeOfType<Learner>();
        }
    }
}
