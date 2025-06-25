using Application.Features.ResourceFeature.GetAllResources;
using Application.Repositories.PokeAPIRepo;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;


namespace Persistence.Repositories
{
    public class ResourceRepository : BaseRepository<EntityResource>, IResourceRepository
    {
        public ResourceRepository(DotPokeNETContext context) : base(context)
        {
        }

        public Task<List<EntityResource>> GetAllResources(GetAllResourcesDTO.Request request, CancellationToken cancellationToken)
        {
            Task<List<EntityResource>>? pokeAPIs = Context.Resource
                .AsNoTracking()
                .Where(
                    x => x.Status == 'A')
                .ToListAsync(cancellationToken);

            return pokeAPIs;
        }
    }
}
