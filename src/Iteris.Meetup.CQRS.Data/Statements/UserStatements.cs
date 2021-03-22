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

        public static string GetById => @"
        SELECT
            ID as Id
            , NAME as Name
            , SURNAME as Surname
            , BIRTHDAY as Birthday
            , CPF as Cpf
        FROM
            USER
        WHERE
            ID = @userId ";
    }
}
