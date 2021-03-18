using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Iteris.Meetup.Domain.Responses
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
        public string GetContentAsJsonString => JsonSerializer.Serialize(Content);

        public static Response Fail(HttpStatusCode statusCode, string errorMessage)
        {
            return Fail(statusCode, new[] {errorMessage});
        }

        public static Response Fail(HttpStatusCode statusCode, params string[] errorMessages)
        {
            var response = new Response();
            response.StatusCode = (int) statusCode;
            response.ErrorMessages.AddRange(errorMessages.ToList());
            return response;
        }

        public static Response Ok()
        {
            var response = new Response();
            response.Content = string.Empty;
            return response;
        }

        public static Response Ok(object content)
        {
            var response = new Response();
            response.Content = content;
            return response;
        }
    }
}