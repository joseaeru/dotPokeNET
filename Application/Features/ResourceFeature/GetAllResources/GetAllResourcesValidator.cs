using FluentValidation;

namespace Application.Features.ResourceFeature.GetAllResources
{
    public sealed class GetAllResourcesValidator : AbstractValidator<GetAllResourcesDTO.Request>
    {
        public GetAllResourcesValidator()
        {
            RuleFor(x => x.Resource)
                .Must(r => 
                    r == null || 
                    r.ResourceCode <= 0 && 
                    r.ResourceName.Trim().Equals(string.Empty)
                )
                .WithMessage("[Resource] must be empty.");
        }
    }

}
