using Microsoft.Extensions.Options;
using Moq;
using Clean.Architecture.Application.Models;
using Clean.Architecture.Application.Services.DateTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.UnitTest.Mocks
{
    public class ConfigMock
    {
        public static Mock<IOptions<FailoverModeSettings>> GetFailoverModeSettings()
        {   var _configData  = new FailoverModeSettings { FrequencyToCheckInMinutes = -10, IsFailoverModeEnabled = true, NumberOfFailedRequestsToCheck = 1 };
            var mockFailoverModeSettings = new Mock<IOptions<FailoverModeSettings>>();
            mockFailoverModeSettings.Setup(prop => prop.Value).Returns(_configData);

            return mockFailoverModeSettings;
        }
    }
}
