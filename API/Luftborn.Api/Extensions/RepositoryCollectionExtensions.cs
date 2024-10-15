using Luftborn.Core.Interfaces.IRepository;
using Luftborn.Infrastructure.Repositories;

namespace Luftborn.Api.Extensions
{
    public static class RepositoryCollectionExtensions
    {
        public static void AddCustomRepository(this IServiceCollection services)
        {
            // Register your services here
            services.AddScoped<ITasksRepository, TasksRepository>();


        }
    }
}
