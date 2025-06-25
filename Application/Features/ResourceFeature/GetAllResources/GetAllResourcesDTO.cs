using MediatR;


namespace Application.Features.ResourceFeature.GetAllResources
{
    public class GetAllResourcesDTO : BaseDTO
    {
        public sealed record Request : IRequest<Response>
        {
            public ResourceObj Resource { get; set; } = new();
        }

        public sealed record Response
        {
            public List<ResourceObj> Resources { get; set; } = [];
        }

        public sealed record ResourceObj
        {
            public int ResourceCode { get; set; } = -1;
            public string ResourceName { get; set; } = string.Empty;
        }
    }
}
