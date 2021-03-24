using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Iteris.Meetup.CQRS.Application
{
    public class Response
    {
        private Response()
        {
            ErrorMessages = new List<string>();
        }

        public object Content { get; private set; }
        public List<string> ErrorMessages { get; }
        public int StatusCode { get; private set; }
        public bool IsFailure => ErrorMessages.Any();
        public object GetResponse => IsFailure ? ErrorMessages : Content;

        public static Response Fail(HttpStatusCode statusCode, string errorMessage)
        {
            return Fail(statusCode, new[] {errorMessage});
        }

        public static Response Fail(HttpStatusCode statusCode, params string[] errorMessages)
        {
            var response = new Response {StatusCode = (int) statusCode};
            response.ErrorMessages.AddRange(errorMessages.ToList());
            return response;
        }

        public static Response Ok()
        {
            return Ok(HttpStatusCode.OK, string.Empty);
        }

        public static Response Ok(HttpStatusCode statusCode)
        {
            return Ok(statusCode, string.Empty);
        }

        public static Response Ok(object content)
        {
            return Ok(HttpStatusCode.OK, content);
        }

        public static Response Ok(HttpStatusCode statusCode, object content)
        {
            var response = new Response {Content = content, StatusCode = (int) statusCode};
            return response;
        }
    }
}