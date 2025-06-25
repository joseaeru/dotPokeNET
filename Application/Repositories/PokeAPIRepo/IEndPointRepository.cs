using Application.Features.EndPointFeature.GetAllEndPoint;
using Application.Features.EndPointFeature.GetEndPoint;
using Domain.Entities;


namespace Application.Repositories.PokeAPIRepo
{
    public interface IEndPointRepository : IBaseRepository<EntityPokeAPI>
    {
        Task<EntityPokeAPI> GetEndPoint(GetEndPointDTO.Request request, CancellationToken cancellationToken);
        Task<List<EntityPokeAPI>> GetAllEndPoint(GetAllEndPointDTO.Request request, CancellationToken cancellationToken);
    }
}
