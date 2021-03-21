using System;

namespace Iteris.Meetup.CQRS.Application
{
    public struct ErrorResponse
    {
        public ErrorResponse(Error error)
            : this(Guid.NewGuid().ToString(), error)
        {
        }

        public ErrorResponse(string requestId, Error error)
        {
            Error = error;
            RequestId = requestId;
        }

        public Error Error { get; }

        public string RequestId { get; }
    }
}