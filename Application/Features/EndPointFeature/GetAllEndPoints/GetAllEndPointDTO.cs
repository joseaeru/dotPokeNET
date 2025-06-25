using MediatR;


namespace Application.Features.EndPointFeature.GetAllEndPoint
{
    public class GetAllEndPointDTO : BaseDTO
    {
        public sealed record Request : IRequest<Response>
        {
            public ValidResources Resource { get; set; } = ValidResources.NONE;
        }

        public sealed record Response
        {
            public List<string> EndPoints { get; set; } = new List<string>();
        }

    }
}
