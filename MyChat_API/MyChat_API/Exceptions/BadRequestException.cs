namespace MyChat_API.Exceptions
{
    public class BadRequestException : Exception
    {
        public int StatusCode;

        public int? StatusCodeCustom;

        public BadRequestException(string message, int statusCode, int? statusCodeCustom = 0) : base(message)
        {
            StatusCode = statusCode;
            StatusCodeCustom = statusCodeCustom;
        }
    }
}
