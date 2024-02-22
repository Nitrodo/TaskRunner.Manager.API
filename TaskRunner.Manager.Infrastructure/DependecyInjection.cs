using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskRunner.Manager.Infrastructure.Persitence;
using TaskRunner.Manager.Application.Mappers;
using TaskRunner.Manager.Infrastructure.Persitence.Interfaces;
using TaskRunner.Manager.Application.Interfaces;
using TaskRunner.Manager.Application.Services;

namespace TaskRunner.Manager.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseContext")));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<DbContext>();
            services.AddScoped<IProcessDefinitionService, ProcessDefinitionService>();
            services.AddScoped<ITaskDefinitionService, TaskDefinitionService>();

            return services;
        }
    }
}
