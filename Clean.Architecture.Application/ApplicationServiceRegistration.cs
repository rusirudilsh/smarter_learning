using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clean.Architecture.Application.Models;
using Clean.Architecture.Application.Services.ActiveLearners;
using Clean.Architecture.Application.Services.ArchivedLearners;
using Clean.Architecture.Application.Services.DateTimes;

namespace Clean.Architecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FailoverModeSettings>(configuration.GetSection("FailoverModeSettings"));
            services.AddScoped<ILearnerService, LearnerService>();
            services.AddScoped<IArchivedLearnerService, ArchivedLearnerService>();
            services.AddSingleton<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}
