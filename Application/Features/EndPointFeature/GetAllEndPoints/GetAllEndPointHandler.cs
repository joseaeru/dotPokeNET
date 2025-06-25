using Application.Repositories;
using Application.Repositories.PokeAPIRepo;
using Domain.Entities;
using MediatR;


namespace Application.Features.EndPointFeature.GetAllEndPoint
{
    public sealed class GetAllEndPointHandler : IRequestHandler<GetAllEndPointDTO.Request, GetAllEndPointDTO.Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEndPointRepository _pokeAPIRepository;

        public GetAllEndPointHandler(IUnitOfWork unitOfWork, IEndPointRepository endPointRepository)
        {
            _unitOfWork = unitOfWork;
            _pokeAPIRepository = endPointRepository;
        }

        public async Task<GetAllEndPointDTO.Response> Handle(GetAllEndPointDTO.Request request, CancellationToken cancellationToken)
        {
            GetAllEndPointDTO.Response response = new();

            Task<List<EntityPokeAPI>>? retorno = _pokeAPIRepository.GetAllEndPoint(request, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            List<EntityPokeAPI> pokeAPIs = (List<EntityPokeAPI>)retorno.Result;

            foreach (EntityPokeAPI pokeAPI in pokeAPIs)
            {
                string? url = string.Concat(
                    pokeAPI.Domain,
                    pokeAPI.Permalink,
                    pokeAPI.Slug,
                    pokeAPI.Resource,
                    pokeAPI.Parameter
                );

                response.EndPoints.Add(url);
            }

            return response;
        }

    }
}
