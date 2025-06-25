using MediatR;


namespace Application.Features.EndPointFeature.GetEndPoint
{
    public class GetEndPointDTO : BaseDTO
    {
        public sealed record Request : IRequest<Response>
        {
            public Guid Id { get; set; }
            public ValidResources Resource { get; set; } = ValidResources.NONE;
            public string Parameter { get; set; } = string.Empty;
        }

        public sealed record Response
        {
            public string EndPoint { get; set; } = string.Empty;
        }

    }
}
