using Application.Features.EndPointFeature.GetEndPoint;
using Application.Features.ResourceFeature.GetAllResources;
using Application.Repositories.PokeAPIRepo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using System.Reflection;

namespace WebAPI.Extensions
{
    public static class ApiBehaviorExtensions
    {
        public static void ConfigureApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;// Suppress the default model state invalid filter to allow custom error handling
            });// Configure API behavior options

            services.AddScoped<IEndPointRepository, EndPointRepository>();// Add the EndPointRepository to the DI container
            services.AddScoped<IResourceRepository, ResourceRepository>();// Add the ResourceRepository to the DI container

            services.AddMediatR(typeof(GetEndPointHandler).Assembly);// Register MediatR handlers from the GetEndPointHandler assembly
            services.AddMediatR(typeof(GetAllResourcesHandler).Assembly);// Register MediatR handlers from the GetAllResourcesHandler assembly
            services.AddMediatR(Assembly.GetExecutingAssembly());// Register MediatR handlers from the current assembly
            services.AddOptions();// Add options support to the DI container
        }
    }
}
