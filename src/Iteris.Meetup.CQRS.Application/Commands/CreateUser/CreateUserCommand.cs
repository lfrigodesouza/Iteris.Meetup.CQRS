using MediatR;
using System;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Cpf { get; set; }
        public string AddressName { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string Complement { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}