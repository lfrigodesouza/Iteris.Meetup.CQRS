using System;
using Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate;

namespace Iteris.Meetup.CQRS.Test.Fakes
{
    public static class UserFake
    {
        public static User Valid()
        {
            return new("Lara", "Barros Goncalves", DateTime.Now, "57237123491");
        }
    }
}