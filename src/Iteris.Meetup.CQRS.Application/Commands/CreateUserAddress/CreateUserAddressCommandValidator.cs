using System.Globalization;
using System.Text.RegularExpressions;
using FluentValidation;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUserAddress
{
    public class CreateUserAddressCommandValidator : AbstractValidator<CreateUserAddressCommand>
    {
        public CreateUserAddressCommandValidator()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            RuleFor(x => x.StreetName).NotEmpty();
            RuleFor(x => x.StreetNumber).GreaterThan(0);
            RuleFor(x => x.Cep).Custom((c, context) =>
            {
                if (!Regex.Match(c.ToString(), "^[0-9]{8}$").Success)
                    context.AddFailure("CEP inválido");
            });
            RuleFor(x => x.State).NotEmpty().Length(2);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}