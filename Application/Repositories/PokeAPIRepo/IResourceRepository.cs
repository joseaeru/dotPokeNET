using Application.Features.ResourceFeature.GetAllResources;
using Domain.Entities;


namespace Application.Repositories.PokeAPIRepo
{
    public interface IResourceRepository : IBaseRepository<EntityResource>
    {
        Task<List<EntityResource>> GetAllResources(GetAllResourcesDTO.Request request, CancellationToken cancellationToken);
    }
}
