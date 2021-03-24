using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;

namespace Iteris.Meetup.CQRS.Test.Fakes
{
    public static class AddressFake
    {
        public static Address Valid()
        {
            return new()
            {
                Name = "Casa",
                UserId = 19,
                StreetName = "Rua Komakite Ikeda",
                StreetNumber = 1592,
                Cep = "18303260",
                City = "Capão Bonito",
                State = "SP",
                Id = 10,
                Complement = "Apto 18"
            };
        }
    }
}