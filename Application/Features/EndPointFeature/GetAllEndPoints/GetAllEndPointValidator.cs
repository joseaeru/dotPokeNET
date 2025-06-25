using FluentValidation;

namespace Application.Features.EndPointFeature.GetAllEndPoint
{
    public sealed class GetAllEndPointValidator : AbstractValidator<GetAllEndPointDTO.Request>
    {
        public GetAllEndPointValidator()
        {
            RuleFor(x => x.Resource)
                .NotEmpty()
                .Must(i => Enum.IsDefined(typeof(BaseDTO.ValidResources), i))
                .Equal(BaseDTO.ValidResources.ALL)
                .WithMessage("[Resource] does not have the correct value.");
        }
    }

}
