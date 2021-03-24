namespace Iteris.Meetup.CQRS.Application.Models
{
    public class UserAddress
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}