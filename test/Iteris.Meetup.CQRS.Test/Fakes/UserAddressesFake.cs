using System.Collections.Generic;
using Iteris.Meetup.CQRS.Application.Models;

namespace Iteris.Meetup.CQRS.Test.Fakes
{
    public static class UserAddressesFake
    {
        public static List<UserAddress> ValidAddresses()
        {
            var response = new List<UserAddress>();
            response.AddRange(
                new List<UserAddress>
                {
                    new()
                    {
                        Cep = "35182380",
                        City = "Timóteo",
                        Name = "Casa",
                        State = "MG",
                        Street = "Rua Um, 232"
                    },
                    new()
                    {
                        Name = "Trabalho",
                        Street = "Rua Roberto Cruz, 1858, sala 3",
                        Cep = "35501382",
                        City = "Divinópolis",
                        State = "MG"
                    }
                }
            );
            return response;
        }
    }
}