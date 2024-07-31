using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineVotingSystem.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace OnlineVotingSystem.Infrastructure
{
    public static class Startup
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {


           
                services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer("Your connection string"));
            



            // Configure the AuthDbContext
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Configure ASP.NET Core Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
