using System;
using FluentValidation;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.Domain.Enums;

namespace Iteris.Meetup.CQRS.Command.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Active).Equal(true);
            RuleForEach(x => x.AcceptedSubscriptionTypes).Custom((m, context) =>
            {
                if (!Enum.IsDefined(typeof(SubscriptionType), m))
                    context.AddFailure("Tipo de assinatura inválida");
            });
        }
    }
}