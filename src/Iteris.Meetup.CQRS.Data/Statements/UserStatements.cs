namespace Iteris.Meetup.CQRS.Data.Statements
{
    public static class UserStatements
    {
        public static string CreateUser => @"
        INSERT
            INTO
            USER (NAME,
            SURNAME,
            BIRTHDAY,
            CPF)
        VALUES(@name,
        @surname,
        @birthday,
        @cpf);
        ";
    }
}