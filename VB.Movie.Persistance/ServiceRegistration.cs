using Microsoft.Extensions.DependencyInjection;
using VB.Movie.Application.Interfaces.Repositories;
using VB.Movie.Persistence.Context;
using VB.Movie.Persistence.Repositories;

namespace VB.Movie.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddTransient<IMovieRepository, MovieRepository>();
        }
    }
}
