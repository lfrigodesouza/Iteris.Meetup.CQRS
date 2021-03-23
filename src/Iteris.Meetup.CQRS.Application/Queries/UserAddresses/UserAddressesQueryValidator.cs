using FluentValidation;

namespace Iteris.Meetup.CQRS.Application.Queries.UserAdresses
{
    public class UserAddressesQueryValidator : AbstractValidator<UserAddressesQuery>
    {
        public UserAddressesQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}