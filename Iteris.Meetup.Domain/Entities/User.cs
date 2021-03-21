using System;

namespace Iteris.Meetup.Domain.Entities
{
    public class User
    {
        public User(string name, string surname, DateTime birthday, string cpf)
        {
            Cpf = cpf;
            Name = name;
            Surname = surname;
            Birthday = new DateTime(birthday.Year, birthday.Month, birthday.Day);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Cpf { get; set; }
        public int Age => DateTime.Now.Year - Birthday.Year;

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}