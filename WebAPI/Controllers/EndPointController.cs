using Application.Features;
using Application.Features.EndPointFeature.GetEndPoint;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/EndPoint")]
    public class EndPointController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EndPointController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{resource}/{parameter}")]
        public async Task<ActionResult<GetEndPointDTO.Response>> Get(string resource, string parameter, CancellationToken cancellationToken)
        {
            GetEndPointDTO.Response response = await _mediator
                .Send(new GetEndPointDTO.Request()
                {
                    Parameter = parameter,
                    Resource = BaseDTO.GetResourceValue(resource)
                    //Resource = resource
                }, cancellationToken);
            return Ok(response);
        }
    }
}
