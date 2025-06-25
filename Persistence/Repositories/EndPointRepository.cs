using Application.Features.EndPointFeature.GetAllEndPoint;
using Application.Features.EndPointFeature.GetEndPoint;
using Application.Repositories.PokeAPIRepo;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;


namespace Persistence.Repositories
{
    public class EndPointRepository : BaseRepository<EntityPokeAPI>, IEndPointRepository
    {
        public EndPointRepository(DotPokeNETContext context) : base(context)
        {
        }

        public Task<EntityPokeAPI> GetEndPoint(GetEndPointDTO.Request request, CancellationToken cancellationToken)
        {
            Task<EntityPokeAPI>? pokeAPI = Context.PokeAPI
                .AsNoTracking()
                .FirstAsync(
                    x => x.InternalID == request.Resource.ToString()
                    && x.Status == 'A'
                , cancellationToken);

            return pokeAPI;
        }

        public Task<List<EntityPokeAPI>> GetAllEndPoint(GetAllEndPointDTO.Request request, CancellationToken cancellationToken)
        {
            Task<List<EntityPokeAPI>>? pokeAPIs = Context.PokeAPI.Include("Resource")
                .AsNoTracking()
                .Where(
                x => x.Status == 'A').ToListAsync(cancellationToken);

            return pokeAPIs;
        }


    }
}
