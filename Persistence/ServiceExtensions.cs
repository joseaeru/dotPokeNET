using Application.Repositories;
using Persistence.Context;
using Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Application.Repositories.PokeAPIRepo;


namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<DotPokeNETContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEndPointRepository, EndPointRepository>();
        }
    }

}
