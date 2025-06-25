namespace Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string> Errors { get; set; }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(List<string> errors) : base($"{string.Join(", ", errors)}")
        {
            Errors = errors;
        }
    }
}
