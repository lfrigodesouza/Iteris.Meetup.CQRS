using FluentValidation;
using Iteris.Meetup.CQRS.Command.Commands;

namespace Iteris.Meetup.CQRS.Command.Validators
{
    public class ToggleProductActivationValidator : AbstractValidator<ToggleProductActivationCommand>
    {
        public ToggleProductActivationValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
        }
    }
}