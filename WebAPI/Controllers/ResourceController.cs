using Application.Features.ResourceFeature.GetAllResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/Resource")]
    public class ResourceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All")]
        public async Task<ActionResult<GetAllResourcesDTO.Response>> GetAll(CancellationToken cancellationToken)
        {
            GetAllResourcesDTO.Response response = await _mediator
                .Send(new GetAllResourcesDTO.Request(), cancellationToken);
            return Ok(response);
        }
    }
}
