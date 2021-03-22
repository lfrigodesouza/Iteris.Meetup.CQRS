namespace Iteris.Meetup.CQRS.Data.Statements
{
    public static class AddressStatements
    {
        public static string CreateAddress = @"
            INSERT
                INTO
                ADDRESS (USERID,
                STREET_NAME,
                STREET_NUMBER,
                COMPLEMENT,
                CEP,
                CITY,
                STATE,
                NAME)
            VALUES(@userId,
            @streetName,
            @streetNumber,
            @complement,
            @cep,
            @city,
            @state,
            @name); ";


        public static string GetById = @"
            SELECT
                ID as Id,
                USERID as UserId,
                STREET_NAME as StreetName,
                STREET_NUMBER as StreetNumber,
                COMPLEMENT as Complement,
                CEP as Cep,
                CITY as City,
                STATE as State,
                NAME as Name
            FROM
                ADDRESS
            WHERE ID = @addressId ";

        public static string GetByUserId = @"
            SELECT
                ID as Id,
                USERID as UserId,
                STREET_NAME as StreetName,
                STREET_NUMBER as StreetNumber,
                COMPLEMENT as Complement,
                CEP as Cep,
                CITY as City,
                STATE as State,
                NAME as Name
            FROM
                ADDRESS
            WHERE USERID = @userId ";
    }
}
