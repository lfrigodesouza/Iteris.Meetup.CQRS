using System;
using FluentValidation;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.Domain.Enums;

namespace Iteris.Meetup.CQRS.Command.Validators
{
    public class AddUserSubscriptionCommandValidator : AbstractValidator<AddUserSubscriptionCommand>

    {
        public AddUserSubscriptionCommandValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.DtStart).GreaterThan(DateTime.Now.AddDays(-1));
            RuleFor(x => x.SubscriptionType).Custom((m, context) =>
            {
                if (!Enum.IsDefined(typeof(SubscriptionType), m))
                    context.AddFailure("Tipo de assinatura inválida");
            });
        }
    }
}