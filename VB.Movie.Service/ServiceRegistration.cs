using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VB.Movie.Application.Interfaces.Wrappers;
using VB.Movie.Application.Wrappers;

namespace VB.Movie.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();


            services.AddMediatR(assm);
        }
    }
}
