using FluentValidation;

namespace Application.Features.EndPointFeature.GetEndPoint
{
    public sealed class GetEndPointValidator : AbstractValidator<GetEndPointDTO.Request>
    {
        public GetEndPointValidator()
        {
            RuleFor(x => x.Resource)
                .Must(i => Enum.IsDefined(typeof(BaseDTO.ValidResources), i))
                .WithMessage("[Resource] debe estar dentro de lo normado.");
            RuleFor(x => x.Parameter)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(20)
                .WithMessage("[Parameter] no debe ser vacio.");
        }
    }
}
