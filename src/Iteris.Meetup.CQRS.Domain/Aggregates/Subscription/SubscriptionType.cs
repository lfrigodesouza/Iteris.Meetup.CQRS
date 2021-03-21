namespace Iteris.Meetup.CQRS.Domain.Aggregates.Subscription
{
    public enum SubscriptionType : byte
    {
        Monthly = 0,
        Annual = 1,
        Lifetime = 2
    }
}