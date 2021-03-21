using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Domain.SeedWorks
{
    public class Result
    {
        protected Result()
        {
            Messages = new HashSet<string>();
        }
        public Result(object value)
        {
            Value = value;
        }

        protected Result(string message) : this()
        {
            Messages.Add(message);
        }

        protected Result(IEnumerable<string> messages) : this()
        {
            Messages.UnionWith(messages);
        }

        public object Value { get; }

        public ISet<string> Messages { get; }

        public bool IsFailure => !IsSuccess;

        public bool IsSuccess => Messages.Count == 0;

        public static Result Ok() => new Result();
        public static Result Ok(object value) => new Result(value);

        public static Result Fail(string message) => new Result(message);

        public static Result Fail(IEnumerable<string> messages) => new Result(messages);
    }

}
