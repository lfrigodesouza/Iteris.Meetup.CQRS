using FluentValidation;
using Iteris.Meetup.CQRS.Command.Commands;

namespace Iteris.Meetup.CQRS.Command.Validators
{
    public class AddedSubscriptionNotificationValidator : AbstractValidator<AddedSubscriptionNotification>
    {
        public AddedSubscriptionNotificationValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.ProductName).NotEmpty();
        }
    }
}