using FluentValidation;
using Iteris.Meetup.CQRS.Query.Queries;

namespace Iteris.Meetup.CQRS.Query.Validators
{
    public class UserAddressesQueryValidator : AbstractValidator<UserAddressesQuery>
    {
        public UserAddressesQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}