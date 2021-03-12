namespace Iteris.Meetup.CQRS.Command.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public int[] AcceptedSubscriptionTypes { get; set; }
    }
}