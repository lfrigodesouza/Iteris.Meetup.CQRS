using System.Collections.Generic;

namespace Iteris.Meetup.CQRS.Query.Responses
{
    public class UserAddressesResponse
    {
        public UserAddressesResponse()
        {
            Addresses = new List<UserAddress>();
        }

        public List<UserAddress> Addresses { get; set; }
    }

    public class UserAddress
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
