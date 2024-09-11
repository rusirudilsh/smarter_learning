using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clean.Architecture.Application.Contracts.Persistence;
using Clean.Architecture.Infrastructure.Repositories;
using Clean.Architecture.Infrastructure.ServiceClient;

namespace Clean.Architecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ILearnerResponseRepository, LearnerResponseRepository>();
            services.AddScoped<IFailoverEntryRepository, FailoverEntryRepository>();
            services.AddScoped<IArchivedDataService, ArchivedDataService>();
            services.AddScoped<ILearnerDataAccess, LearnerDataAccess>();

            return services;
        }
    }
}
