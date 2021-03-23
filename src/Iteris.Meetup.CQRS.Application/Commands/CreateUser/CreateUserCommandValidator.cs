using FluentValidation;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Birthday).LessThanOrEqualTo(DateTime.Now.AddYears(-18));
            RuleFor(x => x.StreetName).NotEmpty();
            RuleFor(x => x.StreetNumber).GreaterThan(0);
            RuleFor(x => x.Cep).Custom((c, context) =>
            {
                if (!Regex.Match(c.ToString(), "^[0-9]{8}$").Success)
                    context.AddFailure("CEP inválido");
            });
            RuleFor(x => x.State).NotEmpty().Length(2);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Cpf).NotEmpty().Length(11);
            RuleFor(x => x.AddressName).NotEmpty();
        }
    }
}