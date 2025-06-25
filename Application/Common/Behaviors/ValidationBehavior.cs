using Application.Common.Exceptions;
using FluentValidation;
using MediatR;


namespace Application.Common.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any()) return await next();

            ValidationContext<TRequest> context = new(request);

            List<string>? errors = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .Select(x => x.ErrorMessage)
                .Distinct()
                .ToList();

            int stop = 0;

            if (errors.Any())
            {
                //TODO: Log the errors for debugging purposes
                throw new BadRequestException(errors);
            }

            return await next();
        }

    }
}
