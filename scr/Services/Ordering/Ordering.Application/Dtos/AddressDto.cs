﻿namespace Ordering.Application.Dtos
{
    public record AddressDto
    (
        string FirstName,
        string LastName,
        string EmailAddres,
        string AddressLine,
        string Country,
        string State,
        string ZipCode
    );
}