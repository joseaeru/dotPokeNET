using Application.Repositories;
using Application.Repositories.PokeAPIRepo;
using Domain.Entities;
using MediatR;


namespace Application.Features.ResourceFeature.GetAllResources
{
    public sealed class GetAllResourcesHandler : IRequestHandler<GetAllResourcesDTO.Request, GetAllResourcesDTO.Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResourceRepository _resourceRepository;

        public GetAllResourcesHandler(IUnitOfWork unitOfWork, IResourceRepository resourceRepository)
        {
            _unitOfWork = unitOfWork;
            _resourceRepository = resourceRepository;
        }

        public async Task<GetAllResourcesDTO.Response> Handle(GetAllResourcesDTO.Request request, CancellationToken cancellationToken)
        {
            Task<List<EntityResource>>? retorno = _resourceRepository.GetAllResources(request, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            List<EntityResource> resources = (List<EntityResource>)retorno.Result;


            GetAllResourcesDTO.Response response = new();

            foreach (EntityResource resource in resources)
            {
                GetAllResourcesDTO.ResourceObj resourceObj = new()
                {
                    ResourceCode = resource.Code,
                    ResourceName = resource.Name.ToUpper().Replace("-", "_"),
                };

                response.Resources.Add(resourceObj);
            }

            return response;
        }

    }
}
