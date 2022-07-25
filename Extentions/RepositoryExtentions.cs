using sponapp.Data;

namespace sponapp.Extentions
{
    public static class RepositoryExtentions
    {
        public static IServiceCollection AddConfigurationRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
