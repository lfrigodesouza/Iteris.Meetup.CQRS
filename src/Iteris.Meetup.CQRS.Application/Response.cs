using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Iteris.Meetup.CQRS.Application
{
    public abstract class Response<TOut> : Response
    {
        protected Response(string requestId)
            : base(requestId)
        {
        }

        public TOut PayLoad { get; protected set; }

        public virtual void SetPayLoad(TOut outPayLoad) => PayLoad = outPayLoad;
    }

    public abstract class Response
    {
        protected Response(string requestId)
        {
            RequestId = requestId;
        }

        protected Response(Request command)
        {
            Command = command;
        }

        [JsonIgnore] public Request Command { get; }

        [JsonIgnore] public ErrorResponse ErrorResponse { get; private set; }

        public void AddError(Error error)
        {
            if (Equals(error, default(Error)))
                return;

            ErrorResponse = new ErrorResponse(RequestId, error);
        }

        [JsonIgnore] public bool IsFailure => !IsSuccess;

        [JsonIgnore] public bool IsSuccess => VerifyResponseIsSuccess();

        public string RequestId { get; }

        private bool VerifyResponseIsSuccess()
            => EqualityComparer<ErrorResponse>.Default.Equals(ErrorResponse, default) || EqualityComparer<Error>.Default.Equals(ErrorResponse.Error, default);

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}