using Iteris.Meetup.CQRS.Application;
using MediatR;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUserAddress
{
    public class CreateUserAddressCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string Complement { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}