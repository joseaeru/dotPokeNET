using Application.Repositories;
using Application.Repositories.PokeAPIRepo;
using Domain.Entities;
using MediatR;


namespace Application.Features.EndPointFeature.GetEndPoint
{
    public sealed class GetEndPointHandler : IRequestHandler<GetEndPointDTO.Request, GetEndPointDTO.Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEndPointRepository _pokeAPIRepository;

        public GetEndPointHandler(IUnitOfWork unitOfWork, IEndPointRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _pokeAPIRepository = userRepository;
        }

        public async Task<GetEndPointDTO.Response> Handle(GetEndPointDTO.Request request, CancellationToken cancellationToken)
        {
            Task<EntityPokeAPI>? retorno = _pokeAPIRepository.GetEndPoint(request, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            EntityPokeAPI pokeAPI = (EntityPokeAPI)retorno.Result;

            GetEndPointDTO.Response response = new GetEndPointDTO.Response();
            response.EndPoint = 
                string.Concat(
                    pokeAPI.Domain,
                    pokeAPI.Permalink,
                    pokeAPI.Slug,
                    $"/{ pokeAPI.InternalID}",
                    pokeAPI.Parameter.Replace("{param}", request.Parameter)
                );

            return response;
        }
    }
}
