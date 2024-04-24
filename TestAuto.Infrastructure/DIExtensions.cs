using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;
using TestAuto.Infrastructure.Services.Repositories.Emplemenatation;

namespace TestAuto.Infrastructure
{
    public static class DIExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<ICoinRepository, CoinRepository>();
        }

        public static void AddMSSQLServer(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlServer(connectionString));
        }

        public static void AddPostgreSQL(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseNpgsql(connectionString));
        }
    }
}
