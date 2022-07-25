using Microsoft.EntityFrameworkCore;
using sponapp.Data;

namespace sponapp.Extentions
{
    public static class DbContextExtensions
    {

        public static IServiceCollection AddConfigureDbContext(this IServiceCollection services ,IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AppDb");
            services.AddDbContext<DataContext>(x => x.UseNpgsql(connectionString));
            return services;
        }
    }
}
