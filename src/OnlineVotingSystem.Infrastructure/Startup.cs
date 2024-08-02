using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineVotingSystem.Infrastructure.Persistence;
using OnlineVotingSystem.Infrastructure.Persistence.Context;

namespace OnlineVotingSystem.Infrastructure
{
    public static class Startup
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("OnlineVotingSystem.Infrastructure")));
        }
    }
}
