using System;
using System.Globalization;
using FluentValidation;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.Domain.Enums;

namespace Iteris.Meetup.CQRS.Command.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            RuleFor(x => x.Age).GreaterThanOrEqualTo(60);
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
        }
    }
}