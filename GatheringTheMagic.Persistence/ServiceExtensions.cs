using GatheringTheMagic.Domain.Interfaces;
using GatheringTheMagic.Persistence.Context;
using GatheringTheMagic.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GatheringTheMagic.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlserver");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
