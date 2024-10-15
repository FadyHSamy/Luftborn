using Luftborn.Core.Interfaces.IServices;
using Luftborn.Core.Mappers.TaskMappers;
using Luftborn.Core.Services;

namespace Luftborn.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddScoped<ITasksServices, TasksServices>();


            services.AddAutoMapper(typeof(TaskProfile));

            services.AddSingleton(provider => provider);

        }
    }
}
